Dropzone.autoDiscover = false;

$(document).ready(function () {
    $(".upload-images").dropzone({
        addRemoveLinks: true,
        maxFileSize: 1,
        autoProcessQueue: false,
        uploadMultiple: true,
        parallelUploads: 100,
        maxFiles: 100,
        paramName: "images",
        previewsContainer: ".cropzone-previews",

    })
})