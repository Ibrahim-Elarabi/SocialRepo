function CheckDeleteGroup(id, uri) {
    event.preventDefault();
    Swal.fire({
        title: 'Do you want to Delete Group?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Save',
        denyButtonText: `Don't save`,
    }).then((result) => {
        if (result.isConfirmed) {
            var _id = id;
            $.ajax({
                type: "post",
                url: uri,
                data: { "id": _id }
            })
            Swal.fire('Deleted!', '', 'success').then((confirm) => { /*window.location.reload();*/ loadDataListGroup(); })
        } else if (result.isDenied) {
            Swal.fire('Changes are not saved', '', 'info')
        }
    })
}