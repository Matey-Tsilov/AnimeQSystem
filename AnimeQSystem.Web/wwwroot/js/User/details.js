export default function init() {
    document.getElementById("ProfilePicForm").addEventListener("change", changeImagePreview)

    // Populate country select
    const select = document.querySelector('#country_select2');
    const preselectedOption = select.querySelector("option");
    $(select).select2();

    fetch('https://restcountries.com/v3.1/all')
        .then(response => response.json())
        .then(data => {
            data.forEach(country => {
                
                // If the select is pre-populated -> there will be one option already which is the selected one, so we skip it
                if (preselectedOption && preselectedOption.textContent != country.name.common) {
                    const option = document.createElement('option');
                    option.textContent = country.name.common;
                    option.value = country.name.common;
                    select.appendChild(option);
                }
            });
        });
}

// Responsible for changing the image on user select for better UX
function changeImagePreview(e) {

    const file = e.target.files[0];
    const previewEl = e.target.parentElement.querySelector("#detailsPreviewImage")

    if (file) {
        // Create a URL for the selected file
        const objectURL = URL.createObjectURL(file);
        // Update the src attribute of the image
        previewEl.src = objectURL;
    }
}


