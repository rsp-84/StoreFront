$("#navbarSupportedContent ul li a").each(function () {
    var fullAnchor = $(this).attr("href");
    

    var aController = fullAnchor.split("/");
 

    var fullPath = (window.location.pathname + location.search).substr(1);


    var fullPath2 = (window.location.pathname + location.search).substr(2);


    var pController = fullPath.split("/");
    

    if (aController[1] == pController[0]) {
        if (aController[2] == pController[1]) {
            $(this).addClass("active");
        }

    }

    if (pController[0].toLowerCase() == "shop") {
        $("#dropDownList").addClass("active");
    }

    var adminLinks = ["categories", "maincategories", "customers", "employees", "orders", "products", "shippers", "suppliers", "usersadmin", "rolesadmin"]

    if ($.inArray(pController[0].toLowerCase(), adminLinks) != -1) {
        $("#dropDownList2").addClass("active");
    }

    if (aController[1] == "Home" && window.location.pathname != fullAnchor) {
        $(this).removeClass("active");
    }
});