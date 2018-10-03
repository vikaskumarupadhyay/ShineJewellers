function displayCreateSubCategoryModal() {
    $('.ui.modal').modal('show');
}

function saveSubCategory() {
    debugger;
    var subCategory = getSubCategoryObject();
    var errorMessage = validateSubCategory(subCategory);
    if (errorMessage == '') {
        hideMessageBoard();
        $.ajax({
            url: '/Category/SaveSubCategory',
            type: 'POST',
            data: JSON.stringify(subCategory),
            contentType: 'application/json',
            success: function (data) {
                if (data != undefined) {
                    displayMessageBoard(data.SaveMessage);
                    if (data.IsSuccess) {
                        window.setTimeout(function () {
                            window.location.reload(true);
                        }, 1000);
                        $('#hdnSubCategoryId').val('0');
                    }
                }
            },
            error: function (x, ex, edx) {

            }
        });
    }
    else {
        displayMessageBoard(errorMessage);
    }
}

function validateSubCategory(category) {
    var message = "";

    if (category.SubCategoryName == undefined || $.trim(category.SubCategoryName) == '') {
        message += "Sub Category Name" + ",";
    }

    if (category.SubCategoryOrder == undefined || category.SubCategoryOrder == '0') {
        message += " Category Order" + ",";
    }

    if (category.ProductCategoryId == undefined || category.ProductCategoryId == '0') {
        message += " Category Item" + ",";
    }

    if (message != '') {

        message = "kindly provide valid " + message.substring(0, message.lastIndexOf(","));
    }

    return message;

}

function getSubCategoryObject() {

    var subCategoryId = $('#hdnSubCategoryId').val();

    var category =
        {
            SubCategoryId: subCategoryId,
            ProductCategoryId: $('#mainCategoryDropDown').val(),
            SubCategoryName: $('#txtSubCategoryName').val(),
            IsActive: true,
            SubCategoryOrder: $('#subCategoryOrderDropDown').val(),
            Content: $('#txtSubCategoryContent').val(),
            RouteControllerName: '',
            RouteActionName: '',
        }
    return category;
}

function displayMessageBoard(message) {
    if ($('#subCategoryMessageBoard').hasClass('hidden')) {
        $('#subCategoryMessageBoard').removeClass('hidden');
    }
    $('#subCategoryMessageBoard').addClass('visible');
    $('#subCategoryMessageBoard').text(message);
}



function hideMessageBoard() {
    if ($('#subCategoryMessageBoard').hasClass('visible')) {
        $('#subCategoryMessageBoard').removeClass('visible');
    }
    $('#subCategoryMessageBoard').addClass('hidden');
    $('#subCategoryMessageBoard').text('');
}


function editSubCategory(subCategoryId) {
    debugger;
    $.ajax({
        url: '/Category/GetSubCategoryDetail',
        type: 'GET',
        data: { subCategoryId: subCategoryId },
        contentType: 'application/json',
        success: function (data) {
            if (data != undefined) {
                $('#hdnSubCategoryId').val(data.SubCategoryId);
                $('#txtSubCategoryName').val(data.SubCategoryName);
                $('#txtSubCategoryContent').val(data.SubCategoryContent);
                debugger;
                $('#subCategoryOrderDropDown').val(data.SubCategoryOrder);
                $('#mainCategoryDropDown').val(data.MainCategoryId);
                hideMessageBoard();
                $('.ui.modal').modal('show');
            }
        },
        error: function (a, ax, adx) {
            $('#hdnSubCategoryId').val('0');
        }
    });

}


function deleteSubCategory(subCategoryId) {
    if (confirm('Are you sure, you want to delete it')) {
        $.ajax({
            url: '/Category/DeleteSubCategory',
            type: 'POST',
            data: { subCategoryId: subCategoryId },
            success: function (data) {
                alert(data.DeleteMessage);
                window.location.href = "/Category/CreateSubMenu";
            },
            error: function (x, ex, dx) {

            }

        });
    }

}


