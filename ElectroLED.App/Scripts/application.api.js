$(document).ready(function () {

    if (sessionStorage.getItem('groups-data') == null) {
        $.getJSON('/api/Action/Groups',
            function (json) {
                var groupsData = JSON.stringify(json);
                sessionStorage.setItem("groups-data", groupsData);
            }).success(function () {

                var electroledGroups = JSON.parse(sessionStorage.getItem('groups-data'));
                fillData(electroledGroups);
            });
    }

    if (sessionStorage.getItem('groups-data') != null) {
        var electroledGroups = JSON.parse(sessionStorage.getItem('groups-data'));
        fillData(electroledGroups);
    }


    function fillData(electroledGroups) {
        //Fill Footed Groups Data
        var headerCount = 0;
        var headerInnerHTML = '';
        electroledGroups.forEach(function (group) {

            if (headerCount === 0) {
                headerInnerHTML += '<div class="row">';
            }

            headerInnerHTML += '<div class="col-sm-3">';
            headerInnerHTML += '<a href="/Group/Select/' + group['id'] + '">';
            headerInnerHTML += '<h5>' + group['name'] + '</h5>';
            headerInnerHTML += '</a>';
            headerInnerHTML += '<ul>';

            group.categories.forEach(function (category) {
                headerInnerHTML += '<li>';
                headerInnerHTML += '<a href="' + '/Category/Products/' + category['id'] + '">' + category['name'] + '</a>';
                headerInnerHTML += '</li>';
            });

            headerInnerHTML += '</ul>';
            headerInnerHTML += '</div>';
            headerCount++;

            if (headerCount === 4) {
                headerCount = 0;
                headerInnerHTML += '</div>';
            }
        });

        $('#headerGroups').html(headerInnerHTML);

        //Fill Footer Groups Data
        var footerCount = 0;
        var footerInnerHTML = '';
        footerInnerHTML += '<h4>Top categories</h4>';
        electroledGroups.forEach(function (group) {
            if (footerCount === 0) {
                footerInnerHTML += '<div class="col-md-4">';
                footerInnerHTML += '<ul>';
            }

            footerInnerHTML += '<li>';
            footerInnerHTML += '<a href="/Group/Select/' + group['id'] + '">' + group['name'] + '</a>';
            footerInnerHTML += '</li>';

            footerCount++;
            if (footerCount === 8) {
                footerInnerHTML += '</ul>';
                footerInnerHTML += '</div>';
                footerCount = 0;
            }

        });

        $('#footerGroups').html(footerInnerHTML);
    }




});