$(document).ready(function () {

    $('.pagination').on('click', 'li[page]', function (event) {
        $('ul.pagination li[class]').removeAttr('class');
        $(this).attr('class', 'active');
        changeSortingRule();
    });

    if (sessionStorage.getItem('sortingRules-data') == null) {
        $.getJSON('/api/Action/SortingRules',
            function (json) {
                var groupsData = JSON.stringify(json);
                sessionStorage.setItem("sortingRules-data", groupsData);
            }).success(function () {

                var electroledRuless = JSON.parse(sessionStorage.getItem('sortingRules-data'));
                renderRules(electroledRuless);
            });
    }

    if (sessionStorage.getItem('sortingRules-data') != null) {
        var electroledRuless = JSON.parse(sessionStorage.getItem('sortingRules-data'));
        renderRules(electroledRuless);
    }
});

function renderRules(electroledRuless) {

    //Fill Footed Groups Data
    var headerInnerHTML = '';
    electroledRuless.forEach(function (rule) {

        headerInnerHTML += '<option>' + rule.name + '</option>';

    });

    $('#sortingRules').html(headerInnerHTML);
    changeSortingRule();
}


function changeSortingRule() {
    var page = $('ul.pagination li[class][class="active"]').attr('page');
    var sorting = $('#sortingRules').val();
    var categoryId = $('ul.breadcrumb li[category]').attr('category');

    $.ajax({
        url: "/api/Action/Products",
        type: "POST",
        data: { page: page, sorting: sorting, categoryId: categoryId },
        success: function (products) {
            renderProducts(products);
        }
    });

}

function renderProducts(products) {
    //Fill Grid Products Data
    var productInnerHTML = '';
    productInnerHTML += '<div class="row products">';
    products.forEach(function (product) {

        productInnerHTML += '<div class="col-md-3 col-sm-4">';
        productInnerHTML += '<div class="product">';
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
            productInnerHTML += '<img src="/Content/Images/ProductImages/notfound.png" alt="' + product.name + '" class="img-responsive gridImage">';
        }

        productInnerHTML += '</a>';
        productInnerHTML += '<div class="text">';
        productInnerHTML += '<h3><a href="/Product/View/' + product.id + '">' + product.name + '</a></h3>';
        productInnerHTML += '<p class="price">' + product.price + '</p>';
        productInnerHTML += '<p class="buttons">';
        productInnerHTML += '<a href="/Product/View/' + product.id + '" class="btn btn-default">View detail</a>';
        productInnerHTML += '</p>';
        productInnerHTML += '</div>';
        productInnerHTML += '</div>';
        productInnerHTML += '</div>';
    });

    productInnerHTML += '</div>';

    $('#container').html(productInnerHTML);

}