mergeInto(LibraryManager.library, {
    DownloadFile: function(array, size, fileNamePtr) {
        // Convert the pointer to a JavaScript string
        var fileName = Pointer_stringify(fileNamePtr);

        // Create a blob from the byte array
        var byteArray = new Uint8Array(size);
        for (var i = 0; i < size; i++) {
            byteArray[i] = getValue(array + i, 'i8');
        }
        var blob = new Blob([byteArray], { type: 'image/png' });

        // Create a temporary download link and click it to download the file
        var url = URL.createObjectURL(blob);
        var downloadLink = document.createElement('a');
        downloadLink.href = url;
        downloadLink.download = fileName;
        document.body.appendChild(downloadLink);
        downloadLink.click();

        // Clean up
        document.body.removeChild(downloadLink);
        URL.revokeObjectURL(url);
    }
});
