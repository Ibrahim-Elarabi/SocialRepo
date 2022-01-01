$("#formEditId").on("submit",function () {
    var _data = $("#formEditId").serialize();
    console.log("Data" + _data);
    $.ajax({
        type: "post",
        url: 'Post/Edit',
        data: _data,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        dataType: 'json',
        success: (res) => {
            if (res.ok == true) {
                $("#form-modal").modal('toggle');
                Swal.fire({
                    position: 'top-end',
                    icon: 'success',
                    title: 'Your Edit saved',
                    showConfirmButton: true

                }).then((confirm) => {
                    if (confirm) {
                        loadData();

                    }
                })

            } else if (res.ok == false) {
                Swal.fire({
                    position: 'top-end',
                    icon: "error",
                    title: 'Your Edit Faild',
                    showConfirmButton: true
                })
            }
        }

    })
}