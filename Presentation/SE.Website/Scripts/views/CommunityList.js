se.ui.view.CommunityList = {};
se.ui.view.CommunityList.rowCommands = {
    editCommunity: function (model) {
        var dialogSettings = {
            container: $('#myModal')
            //okHandler: function (dlgModel) {
            //    if (model.NewPassword == model.NewPassword2) {
            //        dlgModel.AccountId = model.AccountId;
            //        dialog.save("/Account/ChangePassword", dlgModel);
            //    }
            //}
        };
        var dialog = se.ui.control.dialog.factory.get(dialogSettings);
        dialog.show();        
        //se.ui.view.CommunityList.modules.editModule.bindModel(model);
    },
    deleteCommunity: function (model) {
        bootbox.confirm("确定要删除  " + model.Name + "  吗？删除后，不可恢复！", function (isOk) {
            if (isOk) {
                console.log(model.Id);
            }
        });
    }
};

se.ui.view.CommunityList.viewCommands = {
    addCommunity: function (model) {
        $("#myModal").modal("show");
        se.ui.view.CommunityList.modules.editModule.bindModel({});
    }
};

se.ui.view.CommunityList.modules = {
    editModule: new CommunityEditModule(new se.ui.view.EditModule.Settings({
        form: $("form.form-dialog"),
        addUrl: "/Community/Add",
        updateUrl: "/Community/update"
    }))
}



function CommunityEditModule(settings) {
    se.ui.view.EditModule.call(this, settings);
    var _self = this;

    function _init() {
        _self.adaptModel = adaptModel;
        _self.adaptViewModel = adaptViewModel;
    }

    function adaptModel(model) {
        webExpress.ui.control.binders.chinaAreas.buildModel(model);
    }

    function adaptViewModel(viewModel) {
        webExpress.ui.control.binders.chinaAreas.buildViewModel(viewModel);
    }

    _init();
}

