function submitFormGroup() {
    var _data = $("#formEditGroup").serialize();
    $.ajax({
        type: "post",
        url: 'Group/Edit',
        data: _data,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        dataType: 'json',
        success: (res) => {
            if (res.ok == true) {
                $("#form-modal").modal('toggle');
                Swal.fire({
                    position: 'top-end',
                    icon: 'success',
                    title: 'Your Edit Success',
                    showConfirmButton: true

                }).then(
                    (confirm) => {
                        if (confirm) {
                            loadDataListGroup();
                        }
                    }
                )
                //window.location.reload();
            }
        }
    })

}