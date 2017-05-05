$(document).ready(function () {
    $('#recomended').hide();
    productViewAndGetRecomendetProducts();
});

function productViewAndGetRecomendetProducts() {
    var product = $('#productMain').attr('productId');
    $.ajax({
        url: "/api/Action/ProductView",
        type: "POST",
        data: { Id: product },
        success: function(products) {
            renderRecomendetProducts(products);
        }
    });
}

function renderRecomendetProducts(products) {
    //Fill You May aAso Like Section
    if (products) {
        var productInnerHTML = $('#recomended').html();
        products.forEach(function (product) {

            productInnerHTML += '<div class="col-md-3 col-sm-6">';
            productInnerHTML += '<div class="product same-height">';
            productInnerHTML += '<div class="flip-container">';
            productInnerHTML += '<div class="flipper">';
            productInnerHTML += '<div class="front">';
            productInnerHTML += '<a href="/Product/View/' + product.id + '">';
            if (product.defaultImageName !== null) {
                productInnerHTML += '<img src="/Content/Images/ProductImages/' + product.defaultImageName + '" alt="' + product.name + '" class="img-responsive gridImage">';
            } else {
                productInnerHTML += '<img src="/Content/Images/ProductImages/notfound.png" alt="' + product.name + '" class="img-responsive gridImage">';
            }

            productInnerHTML += '</a>';
            productInnerHTML += '</div>';
            productInnerHTML += '<div class="back">';
            productInnerHTML += '<a href="/Product/View/' + product.id + '">';

            if (product.defaultImageName !== null) {
                productInnerHTML += '<img src="/Content/Images/ProductImages/' + product.defaultImageName + '" alt="' + product.name + '" class="img-responsive gridImage">';
            } else {
                productInnerHTML += '<img src="/Content/Images/ProductImages/notfound.png" alt="' + product.name + '" class="img-responsive gridImage">';
            }

            productInnerHTML += '</a>';
            productInnerHTML += '</div>';
            productInnerHTML += '</div>';
            productInnerHTML += '</div>';
            productInnerHTML += '<a href="/Product/View/' + product.id + '" class="invisible">';
            if (product.defaultImageName !== null) {
                productInnerHTML += '<img src="/Content/Images/ProductImages/' + product.defaultImageName + '" alt="' + product.name + '" class="img-responsive gridImage">';
            } else {
                productInnerHTML += '<img src="/Content/Images/ProductImages/notfound.jpg" alt="' + product.name + '" class="img-responsive gridImage">';
            }

            productInnerHTML += '</a>';
            productInnerHTML += '<div class="text">';
            productInnerHTML += '<h3><a href="/Product/View/' + product.id + '">' + product.name + '</a></h3>';
            productInnerHTML += '<p class="price">' + product.price + '</p>';
            productInnerHTML += '</div>';
            productInnerHTML += '</div>';
            productInnerHTML += '</div>';
        });


        $('#recomended').html(productInnerHTML);
        $('#recomended').show();
    }
    
}