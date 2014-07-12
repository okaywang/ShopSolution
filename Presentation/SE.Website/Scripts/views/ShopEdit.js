
(function () {
    se.ui.view.ShopEdit = ShopEditClass;
    se.ui.view.ShopEdit.Settings = ShopEditSettings;
    function ShopEditClass(settings) {
        se.ui.view.EditViewBase.call(this, settings);
        var _self = this;

        function _init() {
            _self.adaptModel = adaptModel;
            _self.adaptViewModel = adaptViewModel;
        }

        function adaptModel(model) {
            if (model.OpeningTime) {
                model.OpeningTime = model.OpeningTime.Hours + ":" + model.OpeningTime.Minutes;
            }
            if (model.ClosingTime) {
                model.ClosingTime = model.ClosingTime.Hours + ":" + model.ClosingTime.Minutes;
            }
            webExpress.ui.control.binders.chinaAreas.buildModel(model);
            
        }

        function adaptViewModel(viewModel) {
            webExpress.ui.control.binders.chinaAreas.buildViewModel(viewModel);
        }

        _init();
    }

    function ShopEditSettings(settings) {
        se.ui.view.EditViewBase.Settings.call(this, settings);
    }
})();
