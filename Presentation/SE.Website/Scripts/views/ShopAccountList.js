se.view = {};
se.view.ShopAccount = {};
se.view.ShopAccount.commands = {
    changePassword: function (model) {
        var dialogSettings = {
            container: $('#myModal'),
            okHandler: function (dlgModel) {
                if (model.NewPassword == model.NewPassword2) {
                    dlgModel.AccountId = model.AccountId;
                    dialog.save("/Account/ChangePassword", dlgModel);
                }
            }
        };
        var dialog = se.ui.control.dialog.factory.get(dialogSettings);
        dialog.show();
    }
};

