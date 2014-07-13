
(function () {
    se.ui.view.EditModule = EditModuleClass;
    se.ui.view.EditModule.Settings = EditModuleSettings;
    function EditModuleClass(settings) {
        se.ui.view.Module.call(this, settings);
        var _self = this;
        //var _viewModel;
        function _init() {
            _self.init = init;

            _self.bindModel = bindModel;

            _self.viewModel = null;
        }

        function init() {
            attachBindingAttribute();

            initValidation();

            settings.saveButton.click(function () {
                var isValid = settings.form.valid();
                if (isValid) {
                    save();
                }
            });
        }

        function bindModel(model) {
            if (this.adaptModel) {
                this.adaptModel(model);
            }

            _self.viewModel = kendo.observable(model);

            if (this.adaptViewModel) {
                this.adaptViewModel(_self.viewModel);
            }

            kendo.bind(settings.form, _self.viewModel);
        }

        function attachBindingAttribute() {
            var properties = $("[property-name]");
            for (var i = 0; i < properties.length; i++) {
                var $property = $(properties[i]);
                var controlType = $property.attr("control-type");
                var controlBinder = webExpress.ui.control.binders.get(controlType);
                controlBinder.build($property);
            }
        }

        function initValidation() {
            var options = {
                errorElement: "span",
                rules: {}
            };

            var properties = $("[property-name]");
            for (var i = 0; i < properties.length; i++) {
                var $property = $(properties[i]);
                var strRule = $property.attr("validate-rule");
                if (strRule) {
                    var rules = webExpress.utility.string.getObject(strRule);
                    var propName = $property.attr("property-name");
                    options.rules[propName] = rules;
                }
            }

            settings.form.validate(options);
        }

        function save() {
            var model = settings.getSaveModel(_self.viewModel);
            var url = settings.getSaveModelId(model) > 0 ? settings.updateUrl : settings.addUrl;
            $(".panel-body").mask("loading...");
            webExpress.utility.ajax.request(url, model,
            function (response) {
                $(".panel-body").unmask();
                if (response.IsSuccess) {
                    _self.inactivate();
                } else {
                    alert("保存错误," + response.Message);
                }
            });
        }

        _init();
    }

    function EditModuleSettings(settings) {
        se.ui.view.Module.Settings.call(this);

        this.getSaveModel = function (viewModel) {
            return viewModel;
        }
        this.getSaveModelId = function (saveModel) {
            return saveModel.Id;
        };
        this.form = $("form", settings.container);
        this.saveButton = $(".btn-save", settings.container);
        this.addUrl = "";
        this.updateUrl = "";

        $.extend(this, settings);
    }
})();
