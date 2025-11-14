document.querySelectorAll('.confirm-delete').forEach(form => {

    form.addEventListener('submit', function (e) {
        e.preventDefault();

        Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!"
        }).then((result) => {
            if (result.isConfirmed) {
                form.submit();
            }

            // if (result.isConfirmed) {
            //   Swal.fire({
            //     title: "Deleted!",
            //     text: "Your file has been deleted.",
            //     icon: "success"
            //   });
            // }
        });


        // if (confirm('Are you sure you want to delete this skill?')) {
        //     form.submit();
        // }
    });


});