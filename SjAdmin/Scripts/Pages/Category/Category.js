function displayCreateCategoryModal() {
    $('.ui.modal').modal('show');
}

function saveCategory() {
    var category= getCategoryObject();
    var errorMessage = validateCategory(category);
    if (errorMessage == '') {
        hideMessageBoard();
        $.ajax({
            url: '/Category/SaveCategory',
            type: 'POST',
            data: JSON.stringify(category),
            contentType: 'application/json',
            success: function (data)
            {
                if (data != undefined) {
                    displayMessageBoard(data.SaveMessage);
                    if (data.IsSuccess) {
                        window.setTimeout(function () {
                            window.location.reload(true);
                        }, 1000);
                        $('#hdnCategoryId').val('0');
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

function validateCategory(category)
{
    var message = "";

    if (category.ProductCategoryName == undefined || $.trim(category.ProductCategoryName) == '') {
        message += " Category Name" + ",";
    }

    if (category.CategoryOrder == undefined || category.CategoryOrder == '0') {
        message += " Category Order" + ",";
    }
    if (message != '') {

        message = "kindly provide valid "+message.substring(0,message.lastIndexOf(","));
    }
       
    return message;

}

function getCategoryObject() {

    var categoryId = $('#hdnCategoryId').val();

    var category =
        {
            ProductCategoryId: categoryId,
            ProductCategoryName: $('#txtCategoryName').val(),
            IsActive: true,
            CategoryOrder: $('#categoryOrderDropDown').val(),
            Content: $('#txtCategoryContent').val(),
            RouteControllerName: '',
            RouteActionName:'',
        }
    return category;
}

function displayMessageBoard(message) {
    if ($('#categoryMessageBoard').hasClass('hidden')) {
        $('#categoryMessageBoard').removeClass('hidden');
    }
    $('#categoryMessageBoard').addClass('visible');
    $('#categoryMessageBoard').text(message);
}



function hideMessageBoard() {
    if ($('#categoryMessageBoard').hasClass('visible')) {
        $('#categoryMessageBoard').removeClass('visible');
    }
    $('#categoryMessageBoard').addClass('hidden');
    $('#categoryMessageBoard').text('');
}


function editCategory(categoryId) {
    debugger;
    $.ajax({
        url: '/Category/GetCategoryInformation',
        type: 'GET',
        data: { categoryId: categoryId },
        contentType: 'application/json',
        success: function (data) {
            if (data != undefined) {
                debugger;
                $('#hdnCategoryId').val(data.CategoryDetail.ProductCategoryId);
                $('#txtCategoryName').val(data.CategoryDetail.ProductCategoryName);
                $('#txtCategoryContent').val(data.CategoryDetail.Content);
                $('#categoryOrderDropDown').val(data.CategoryDetail.CategoryOrder);
                hideMessageBoard();
                $('.ui.modal').modal('show');
            }
        },
        error: function (a, ax, adx) {
            $('#hdnCategoryId').val('0');
        }
    });

}



function deleteCategory(categoryId) {
    if (confirm('Are you sure, you want to delete it, Sub categories would also be deleted')) {
        $.ajax({
            url: '/Category/DeleteCategory',
            type: 'POST',
            data: { categoryId: categoryId },
            success: function (data) {
                alert(data.DeleteMessage);
                window.location.href = "/Category/CreateMainMenu";
            },
            error: function (x, ex, dx) {

            }

        });
    }

}


