
$("#formID").on("submit", function () {
    event.preventDefault();
    var _data = $("#formID").serialize();
    $.ajax({
        type: "post",
        //url: 'Post/Create',
        url:'@Url.Acrtion()',
        data: _data,
        //contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        dataType: 'json',
        processData: false,
        contentType: false,
        success: (res) => {
            console.log(res);
            if (res.ok == true) {
                $("#form-modal").modal('toggle');
                Swal.fire({
                    position: 'top-end',
                    icon: 'success',
                    title: 'Your Create Success',
                    showConfirmButton: true

                }).then(
                    (confirm) => {
                        if (confirm) {
                            loadData();
                        }
                    }
                )
                
            } else if (res.ok == false) {
                Swal.fire({
                    position: 'top-end',
                    icon: "error",
                    title: 'Your Create Faild',
                    showConfirmButton: true
                })
            }
        }
    })

});

function closeFormCreate() {
    
    $('#form-modal').modal('hide');
}