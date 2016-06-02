(function () {

    appModule.controller('common.views.article.index', [
        '$scope', '$uibModal', '$stateParams', 'uiGridConstants', 'abp.services.app.article',
        function ($scope, $uibModal, $stateParams, uiGridConstants, articleService) {
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            vm.loading = false;
            vm.filterText = $stateParams.filterText || '';
            vm.currentUserId = abp.session.userId;

            vm.permissions = {
                create: abp.auth.hasPermission('Pages.YouChat.Article.Create'),
                edit: abp.auth.hasPermission('Pages.YouChat.Article.Edit'),
                'delete': abp.auth.hasPermission('Pages.YouChat.Article.Delete')
            };

            var requestParams = {
                skipCount: 0,
                maxResultCount: app.consts.grid.defaultPageSize,
                sorting: null
            };

            vm.articleGridOptions = {
                enableHorizontalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                enableVerticalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                paginationPageSizes: app.consts.grid.defaultPageSizes,
                paginationPageSize: app.consts.grid.defaultPageSize,
                useExternalPagination: true,
                useExternalSorting: true,
                appScopeProvider: vm,
                rowTemplate: '<div ng-repeat="(colRenderIndex, col) in colContainer.renderedColumns track by col.colDef.name" class="ui-grid-cell" ng-class="{ \'ui-grid-row-header-cell\': col.isRowHeader, \'text-muted\': !row.entity.isActive }"  ui-grid-cell></div>',
                columnDefs: [
                    {
                        name: app.localize('Actions'),
                        enableSorting: false,
                        width: 120,
                        cellTemplate:
                            '<div class=\"ui-grid-cell-contents\">' +
                            '  <div class="btn-group dropdown" uib-dropdown="">' +
                            '    <button class="btn btn-xs btn-primary blue" uib-dropdown-toggle="" aria-haspopup="true" aria-expanded="false"><i class="fa fa-cog"></i> ' + app.localize('Actions') + ' <span class="caret"></span></button>' +
                            '    <ul uib-dropdown-menu>' +
                            '      <li><a ng-if="grid.appScope.permissions.edit" ng-click="grid.appScope.editArticle(row.entity)">' + app.localize('Edit') + '</a></li>' +
                            '      <li><a ng-if="grid.appScope.permissions.delete" ng-click="grid.appScope.deleteArticle(row.entity)">' + app.localize('Delete') + '</a></li>' +
                            '    </ul>' +
                            '  </div>' +
                            '</div>'
                    },
                    {
                        name: "标题",
                        field: 'title',
                        minWidth: 120
                    },
                    {
                        name: "内容",
                        field: 'content',
                        minWidth: 200,
                        enableSorting: false
                    },
                    {
                        name: "作者",
                        field: 'userName',
                        minWidth: 200,
                        enableSorting: false
                    },
                    {
                         name: "创建时间",
                         field: 'creationTime',
                         minWidth: 100
                    },
                    {
                        name: "类别",
                        field: 'categoryName',
                        enableSorting: false,
                        minWidth: 100
                    }
                ],
                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                    $scope.gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
                        if (!sortColumns.length || !sortColumns[0].field) {
                            requestParams.sorting = null;
                        } else {
                            requestParams.sorting = sortColumns[0].field + ' ' + sortColumns[0].sort.direction;
                        }

                        vm.getArticle();
                    });
                    gridApi.pagination.on.paginationChanged($scope, function (pageNumber, pageSize) {
                        requestParams.skipCount = (pageNumber - 1) * pageSize;
                        requestParams.maxResultCount = pageSize;

                        vm.getArticle();
                    });
                },
                data: []
            };

            //if (!vm.permissions.edit &&
            //    !vm.permissions.changePermissions &&
            //    !vm.permissions.impersonation &&
            //    !vm.permissions.delete) {
            //    vm.userGridOptions.columnDefs.shift();
            //}

            vm.getArticle = function () {
                vm.loading = true;
                articleService.getArticleList({
                    skipCount: requestParams.skipCount,
                    maxResultCount: requestParams.maxResultCount,
                    sorting: requestParams.sorting,
                    filter: vm.filterText
                }).success(function (result) {
                    vm.articleGridOptions.totalItems = result.totalCount;
                    vm.articleGridOptions.data = result.items;
                }).finally(function () {
                    vm.loading = false;
                });
            };


            function openCreateOrEditArticleModal(articleId) {
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/youchat/views/article/createOrEditModal.cshtml',
                    controller: 'youchat.views.article.createOrEditModal as vm',
                    backdrop: 'static',
                    resolve: {
                        articleId: function () {
                            return articleId;
                        }
                    }
                });

                modalInstance.result.then(function (result) {
                    vm.getArticle();
                });
            }

            vm.editArticle = function (article) {
                openCreateOrEditArticleModal(article.id);
            };

            vm.createArticle = function () {
                openCreateOrEditArticleModal(null);
            };

            //vm.deleteUser = function (user) {
            //    if (user.userName == app.consts.userManagement.defaultAdminUserName) {
            //        abp.message.warn(app.localize("{0}UserCannotBeDeleted", app.consts.userManagement.defaultAdminUserName));
            //        return;
            //    }

            //    abp.message.confirm(
            //        app.localize('UserDeleteWarningMessage', user.userName),
            //        function (isConfirmed) {
            //            if (isConfirmed) {
            //                userService.deleteUser({
            //                    id: user.id
            //                }).success(function () {
            //                    vm.getUsers();
            //                    abp.notify.success(app.localize('SuccessfullyDeleted'));
            //                });
            //            }
            //        }
            //    );
            //};

            vm.getArticle();
        }]);
})();