(function() {
    appModule.controller('youchat.views.article.createOrEditModal', [
        '$scope', '$uibModalInstance',  'meta.umeditor','abp.services.app.article', 'articleId',
        function ($scope, $uibModalInstance,umeditor, atricleSerivce,articleId) {

            var vm = this;


            vm.saving = false;

            vm.article = null;

            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };

            vm.save = function () {
                vm.saving = true;
                atricleSerivce.createOrUpdateArticle({
                    title: vm.article.title,
                    content:vm.article.content
                }).success(function () {
                    abp.notify.info(app.localize('SavedSuccessfully'));
                    $uibModalInstance.close();
                }).finally(function() {
                    vm.saving = false;
                });
            };
        }
    ]);
})();


