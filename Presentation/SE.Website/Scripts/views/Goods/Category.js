
(function () {
    window.Category = CategoryClass;

    function CategoryClass() {
        var _self = this;

        function _init() {
            _self.init = init;
        }

        function init() {
            initValidation();
            initDomEvent();
        }

        function initDomEvent() {
            $('#btnAdd').click(function () {
                $('#myModal from').resetForm();
                $('#myModal').modal();
            });

            
        }

        function initValidation() {
            $(".j-validate").validate({
                rules: {
                    Name: "required",
                    SupplierName: "required",
                    Standard: "required",
                    Price: {
                        required: true,
                        number: true
                    },
                    DiscountPrice: {
                        required: true,
                        number: true
                    },
                    ImageFileName: "required"
                }
            });
        }

        _init();
    }
})();
