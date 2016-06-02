/* 'app' MODULE DEFINITION */
var appModule = angular.module("app", [
    "ui.router",
    "ui.bootstrap",
    'ui.utils',
    "ui.jq",
    'ui.grid',
    'ui.grid.pagination',
    "oc.lazyLoad",
    "ngSanitize",
    'angularFileUpload',
    'daterangepicker',
    'angularMoment',
    'frapontillo.bootstrap-switch',
    'abp'
]);

/* LAZY LOAD CONFIG */

/* This application does not define any lazy-load yet but you can use $ocLazyLoad to define and lazy-load js/css files.
 * This code configures $ocLazyLoad plug-in for this application.
 * See it's documents for more information: https://github.com/ocombe/ocLazyLoad
 */
appModule.config(['$ocLazyLoadProvider', function ($ocLazyLoadProvider) {
    $ocLazyLoadProvider.config({
        cssFilesInsertBefore: 'ng_load_plugins_before', // load the css files before a LINK element with this ID.
        debug: false,
        events: true,
        modules: []
    });
}]);

/* THEME SETTINGS */
App.setAssetsPath(abp.appPath + 'metronic/assets/');
appModule.factory('settings', ['$rootScope', function ($rootScope) {
    var settings = {
        layout: {
            pageSidebarClosed: false, // sidebar menu state
            pageContentWhite: true, // set page content layout
            pageBodySolid: false, // solid body color state
            pageAutoScrollOnLoad: 1000 // auto scroll to top on page load
        },
        layoutImgPath: App.getAssetsPath() + 'admin/layout4/img/',
        layoutCssPath: App.getAssetsPath() + 'admin/layout4/css/',
        assetsPath: abp.appPath + 'metronic/assets',
        globalPath: abp.appPath + 'metronic/assets/global',
        layoutPath: abp.appPath + 'metronic/assets/layouts/layout4'
    };

    $rootScope.settings = settings;

    return settings;
}]);

/* ROUTE DEFINITIONS */

appModule.config([
    '$stateProvider', '$urlRouterProvider',
    function ($stateProvider, $urlRouterProvider) {

        // Default route (overrided below if user has permission)
        $urlRouterProvider.otherwise("/welcome");

        //Welcome page
        $stateProvider.state('welcome', {
            url: '/welcome',
            templateUrl: '~/App/common/views/welcome/index.cshtml'
        });

        //COMMON routes

        if (abp.auth.hasPermission('Pages.Administration.Roles')) {
            $stateProvider.state('roles', {
                url: '/roles',
                templateUrl: '~/App/common/views/roles/index.cshtml',
                menu: 'Administration.Roles'
            });
        }

        if (abp.auth.hasPermission('Pages.Administration.Users')) {
            $stateProvider.state('users', {
                url: '/users?filterText',
                templateUrl: '~/App/common/views/users/index.cshtml',
                menu: 'Administration.Users'
            });
        }

        if (abp.auth.hasPermission('Pages.Administration.Languages')) {
            $stateProvider.state('languages', {
                url: '/languages',
                templateUrl: '~/App/common/views/languages/index.cshtml',
                menu: 'Administration.Languages'
            });

            if (abp.auth.hasPermission('Pages.Administration.Languages.ChangeTexts')) {
                $stateProvider.state('languageTexts', {
                    url: '/languages/texts/:languageName?sourceName&baseLanguageName&targetValueFilter&filterText',
                    templateUrl: '~/App/common/views/languages/texts.cshtml',
                    menu: 'Administration.Languages'
                });
            }
        }

        if (abp.auth.hasPermission('Pages.Administration.AuditLogs')) {
            $stateProvider.state('auditLogs', {
                url: '/auditLogs',
                templateUrl: '~/App/common/views/auditLogs/index.cshtml',
                menu: 'Administration.AuditLogs'
            });
        }

        if (abp.auth.hasPermission('Pages.Administration.OrganizationUnits')) {
            $stateProvider.state('organizationUnits', {
                url: '/organizationUnits',
                templateUrl: '~/App/common/views/organizationUnits/index.cshtml',
                menu: 'Administration.OrganizationUnits'
            });
        }

        $stateProvider.state('notifications', {
            url: '/notifications',
            templateUrl: '~/App/common/views/notifications/index.cshtml'
        });

        //HOST routes

        $stateProvider.state('host', {
            'abstract': true,
            url: '/host',
            template: '<div ui-view class="fade-in-up"></div>'
        });

        if (abp.auth.hasPermission('Pages.Tenants')) {
            $urlRouterProvider.otherwise("/host/tenants"); //Entrance page for the host
            $stateProvider.state('host.tenants', {
                url: '/tenants?filterText',
                templateUrl: '~/App/host/views/tenants/index.cshtml',
                menu: 'Tenants'
            });
        }

        if (abp.auth.hasPermission('Pages.Editions')) {
            $stateProvider.state('host.editions', {
                url: '/editions',
                templateUrl: '~/App/host/views/editions/index.cshtml',
                menu: 'Editions'
            });
        }

        if (abp.auth.hasPermission('Pages.Administration.Host.Maintenance')) {
            $stateProvider.state('host.maintenance', {
                url: '/maintenance',
                templateUrl: '~/App/host/views/maintenance/index.cshtml',
                menu: 'Administration.Maintenance'
            });
        }

        if (abp.auth.hasPermission('Pages.Administration.Host.Settings')) {
            $stateProvider.state('host.settings', {
                url: '/settings',
                templateUrl: '~/App/host/views/settings/index.cshtml',
                menu: 'Administration.Settings.Host'
            });
        }

        //TENANT routes

        $stateProvider.state('tenant', {
            'abstract': true,
            url: '/tenant',
            template: '<div ui-view class="fade-in-up"></div>'
        });

        if (abp.auth.hasPermission('Pages.Tenant.Dashboard')) {
            $urlRouterProvider.otherwise("/tenant/dashboard"); //Entrance page for a tenant
            $stateProvider.state('tenant.dashboard', {
                url: '/dashboard',
                templateUrl: '~/App/tenant/views/dashboard/index.cshtml',
                menu: 'Dashboard.Tenant'
            });
        }

        if (abp.auth.hasPermission('Pages.Administration.Tenant.Settings')) {
            $stateProvider.state('tenant.settings', {
                url: '/settings',
                templateUrl: '~/App/tenant/views/settings/index.cshtml',
                menu: 'Administration.Settings.Tenant'
            });
        }


        // YouChat routes

        if (abp.auth.hasPermission('Pages.YouChat.Article')) {
           // $urlRouterProvider.otherwise("/youchat/article"); //Entrance page for a tenant
            $stateProvider.state('youchat_article', {
                url: '/article',
                templateUrl: '~/App/youchat/views/article/index.cshtml',
                menu: 'YouChat.Article'
            });
        }
    }
]);

appModule.run(["$rootScope", "settings", "$state", 'i18nService', function ($rootScope, settings, $state, i18nService) {
    $rootScope.$state = $state;
    $rootScope.$settings = settings;

    //Set Ui-Grid language
    if (i18nService.get(abp.localization.currentCulture.name)) {
        i18nService.setCurrentLang(abp.localization.currentCulture.name);
    } else {
        i18nService.setCurrentLang("en");
    }

    $rootScope.safeApply = function (fn) {
        var phase = this.$root.$$phase;
        if (phase == '$apply' || phase == '$digest') {
            if (fn && (typeof (fn) === 'function')) {
                fn();
            }
        } else {
            this.$apply(fn);
        }
    };
}]);




appModule.module('meta.umeditor', [])
    .directive('metaUmeditor', function () {
        return {
            restrict: 'AE',
            scope: {
                config: '=metaUmeditorConfig'
            },
            require: 'ngModel',
            transclude: true,
            link: function (scope, element, attr, ngModel) {
                //获取当前的DOM元素
                var _dom = element[0];

                var _id = '_' + Math.floor(Math.random() * 100).toString() + new Date().getTime().toString();

                var _placeholder = '<p style="font-size:14px;color:#ccc;">' +
                    attr.metaUmeditorPlaceholder +
                    '</p>';

                var _config = scope.config || {
                    //这里可以选择自己需要的工具按钮名称,此处仅选择如下七个
                    toolbar: ['source undo redo bold italic underline'],
                    //focus时自动清空初始化时的内容
                    autoClearinitialContent: true,
                    //关闭字数统计
                    wordCount: false,
                    //关闭elementPath
                    elementPathEnabled: false,
                    //frame高度
                    //initialFrameHeight: 300
                };

                _dom.setAttribute('id', _id);

                var _umeditor = UM.getEditor(_id, _config);

                /**
                 * 对于umeditor添加内容改变事件，内容改变触发ngModel改变.
                 */
                var editorToModel = function () {
                    if (_umeditor.hasContents())
                        ngModel.$setViewValue(_umeditor.getContent());
                    else
                        ngModel.$setViewValue(undefined);
                };

                /**
                 * umeditor准备就绪后，执行逻辑
                 * 如果ngModel存在
                 *   则给在编辑器中赋值
                 *   给编辑器添加内容改变的监听事件.
                 * 如果不存在
                 *   则写入提示文案
                 */

                _umeditor.ready(function () {
                    if (ngModel.$viewValue) {
                        _umeditor.setContent(ngModel.$viewValue);
                        _umeditor.addListener('contentChange', editorToModel);
                    } else {
                        _umeditor.setContent(_placeholder);
                    }
                    //_umeditor.execCommand('fontsize', '32px');
                    //_umeditor.execCommand('fontfamily', '"Microsoft YaHei","微软雅黑"')
                });

                /**
                 * 添加编辑器被选中事件
                 * 如果ngModel没有赋值
                 *   清空content
                 *   给编辑器添加内容改变的监听事件
                 */
                _umeditor.addListener('focus', function () {
                    if (!ngModel.$viewValue) {
                        _umeditor.setContent('');
                        _umeditor.addListener('contentChange', editorToModel);
                    }
                });


                /**
                 * 添加编辑器取消选中事件
                 * 如content值为空
                 *   取消内容改变的监听事件
                 *   添加content为提示文案
                 */
                _umeditor.addListener('blur', function () {
                    if (!_umeditor.hasContents()) {
                        _umeditor.removeListener('contentChange', editorToModel);
                        _umeditor.setContent(_placeholder);
                    } else {
                    }
                })

            }
        }
    });