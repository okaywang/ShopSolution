
(function () {
    se.ui.view.ShopEdit = ShopEditClass;
    se.ui.view.ShopEdit.Settings = ShopEditSettings;
    function ShopEditClass(settings) {
        se.ui.view.EditModule.call(this, settings);
        var base = $.extend({}, this);
        var _self = this;

        function _init() {
            _self.adaptModel = adaptModel;
            _self.adaptViewModel = adaptViewModel;
            _self.init = init;
        }
        function init() {
            base.init.call(_self);

            _self.on("updated", function () {
                bootbox.alert("保存成功", function () {
                    location.href = location.href;
                });                
            });
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
        se.ui.view.EditModule.Settings.call(this, settings);
    }
})();
