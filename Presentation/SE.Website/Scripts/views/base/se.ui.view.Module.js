
(function () {
    se.ui.view.Module = ModuleClass;
    se.ui.view.Module.Settings = ModuleSettings;
    function ModuleClass(settings) {
        se.ui.control.Eventable.call(this);
        var _self = this;
        var _settings = settings;
        function _init() {
            _self.activate = activate;

            _self.inactivate = inactivate;
        }

        function activate() {
            _settings.activateHandler.call(this);
        }

        function inactivate() {
            _settings.inactivateHandler.call(this);
        }

        _init();
    }

    function ModuleSettings(settings) {
        this.activateHandler = function () {
        }

        this.inactivateHandler = function () {
        }

        $.extend(this, settings);
    }
})();
