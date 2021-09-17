export function initializeFileDropZone(dropZoneElement, component) {
    function onDragEnter(e){
        e.preventDefault();
        dropZoneElement.classList.add("dropzone-drag");        
    }
    
    function onDragOver(e){
        e.preventDefault();
    }

    function onDragLeave(e) {
        e.preventDefault();
        dropZoneElement.classList.remove("dropzone-drag");
    }

    function onDrop(e) {
        e.preventDefault();
        dropZoneElement.classList.remove("dropzone-drag");

        SendFileContentToBlazor(e.dataTransfer.files);
    }

    function SendFileContentToBlazor(files) {
        component.invokeMethodAsync('ClearContainer');
     
        Promise.all(Array.from(files).map(function (file) {
            let reader = new FileReader();
            return new Promise((resolve, reject) => {
                reader.onload = event => resolve(event.target.result)
                reader.onerror = error => reject(error)
                reader.readAsText(file)
            })
        }))
            .then(contents => {
                for (let i = 0; i < contents.length; i++) {
                    component.invokeMethodAsync('AddFile', contents[i]);
                }
            });
    }

    // Register all events
    dropZoneElement.addEventListener("dragenter", onDragEnter);
    dropZoneElement.addEventListener("dragover", onDragOver);
    dropZoneElement.addEventListener("dragleave", onDragLeave);
    dropZoneElement.addEventListener("drop", onDrop);

    // The returned object allows to unregister the events when the Blazor component is destroyed
    return {
        dispose: () => {
            dropZoneElement.removeEventListener('dragenter', onDragEnter);
            dropZoneElement.removeEventListener('dragover', onDragOver);
            dropZoneElement.removeEventListener('dragleave', onDragLeave);
            dropZoneElement.removeEventListener("drop", onDrop);
        }
    }
}