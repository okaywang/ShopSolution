se.ui.view.ShopAccount = {};
se.ui.view.ShopAccount.rowCommands = {
    changePassword: function (model) {
        viewInstance.modules.changePassword.activate();
        viewInstance.modules.changePassword.bindModel(model);
    }
};

