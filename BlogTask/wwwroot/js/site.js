// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
showInputPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal('toggle');
    }
    })
}
//function loadData() {
//    $.ajax({
//        type: "GET",
//        url: 'Post/GetAllPublicPosts',
//        success: function (res) {

//            $("#listAllPosts").html(res);

//        }
//    });
//}
//function loadDataListGroup() {
//    $.ajax({
//        type: "GET",
//        url: 'Group/GetAll',
//        success: function (res) {

//            $("#listAllGroups").html(res);

//        }
//    });
//}

//$("#formID").on("submit", function () {
//    var _data = $("#formID").serialize();
//    $.ajax({
//        type: "post",
//        url: 'Post/Create',
//        data: _data,
//        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
//        dataType: 'json',
//        success: (res) => {
//            console.log(res);
//            if (res.ok == true) {
//                $("#form-modal").modal('toggle');
//                Swal.fire({
//                    position: 'top-end',
//                    icon: 'success',
//                    title: 'Your Create Success',
//                    showConfirmButton: true

//                }).then(
//                    (confirm) => {
//                        if (confirm) {
//                            loadData();
//                        }
//                    }
//                )

//            } else if (res.ok == false) {
//                Swal.fire({
//                    position: 'top-end',
//                    icon: "error",
//                    title: 'Your Create Faild',
//                    showConfirmButton: true
//                })
//            }
//        }
//    })

//});
