var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/Book/Index";
        });
        $('#btnThanhToan').off('click').on('click', function () {
            window.location.href = "/Cart/PayMent";
        });

        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.txtQuantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    QUANTITY: $(item).val(),
                    PRODUCT: {
                        IDPRODUCTS: $(item).data('id')
                    }
                });
            });
            $.ajax({
                url: '/Cart/Update',
                data: {
                    cartModel: JSON.stringify(cartList),
                },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart/ShoppingCart";
                    }
                }
            });
        });

        //Xoa tat ca
        $('#btnDeleteAll').off('click').on('click', function () {
            $.ajax({
                url: '/Cart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart/ShoppingCart";
                    }
                }
            });
        });
        //Xoa 1 sp
        $('#btnDelete').off('click').on('click', function () {
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart/ShoppingCart";
                    }
                }
            });
        });
    }
}
cart.init();