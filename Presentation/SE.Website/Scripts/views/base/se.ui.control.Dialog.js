(function () {
    se.ui.control.Dialog = DialogClass;
    se.ui.control.dialog = {};
    se.ui.control.dialog.factory = new DialogFactory();
    function DialogClass(settings) {
        se.ui.control.Eventable.call(this);
        var _self = this;

        function _init() {
            _self.show = show;

            _self.hide = hide;

            init();
        }

        function init() {
            settings.container.find(".btn-ok").click(function () {
                var data = settings.container.find("form").serializeObject();
                _self.fire("ok", [data]);
            });
            settings.container.on('hidden.bs.modal', function (e) {
                settings.container.find("form")[0].reset();
            });

            if (module) {
                module.init();
            }
        }

        function show() {
            settings.container.modal("show");
        }

        function hide() {
            settings.container.modal("hide");
        }

        _init();
    }

    function DialogClassSettings(settings) {
        this.container = null;
        this.moudule = null;

        $.extend(this, settings);
    }

    function DialogFactory() {
        var _cache = {};
        var _self = this;

        function _init() {
            _self.get = get;
        }

        function get(settings) {
            if (_cache[settings.container] === undefined) {
                var dialog = new DialogClass(settings);
                //dialog.on("ok", settings.okHandler);
                _cache[settings.container] = dialog;
            }
            return _cache[settings.container];
        }

        _init();
    }
})();
