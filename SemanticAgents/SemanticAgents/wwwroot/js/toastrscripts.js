//function ShowToastr(type, message, duration) {
//    if (type === "success") {
//        // Override global options
//        toastr.success(message, 'Operation Successful', { timeOut: duration });
//    }
//    if (type === "error") {
//        // Override global options
//        toastr.error(message, 'Operation Failed', { timeOut: duration });
//    }
//    if (type === "info") {
//        // Override global options
//        toastr.info(message, 'Information', { timeOut: duration });
//    }
//}

// to change back to original, use below and update Toastr service plus interface and take time arg out of toastr calls on components

function ShowToastr(type, message) {
    if (type === "success") {
        // Override global options
        toastr.success(message, 'Operation Successful', { timeOut: 5000 });
    }
    if (type === "error") {
        // Override global options
        toastr.error(message, 'Operation Failed', { timeOut: 5000 });
    }
    if (type === "info") {
        // Override global options
        toastr.info(message, 'Information', { timeOut: 5000 });
    }
}