export default function init() {

    const select = document.querySelector('#country_select2');
    const preselectedOption = select.querySelector("option");
    $(select).select2();

    fetch('https://restcountries.com/v3.1/all')
        .then(response => response.json())
        .then(data => {
            data.forEach(country => {
                // If the select is pre-populated -> there will be one option already which is the selected one, so we skip it
                if ((preselectedOption && preselectedOption.textContent != country.name.common) || !preselectedOption) {
                    const option = document.createElement('option');
                    option.textContent = country.name.common;
                    option.value = country.name.common;
                    select.appendChild(option);
                }
            });
        });
}