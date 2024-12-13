export default function init() {

    $("#grid").kendoGrid({
        dataSource: {
            transport: {
                read: {
                    url: "/Admin/UserManagement/GetUserManagementData", // URL to your API
                    dataType: "json"// Expected data format
                }
            },
            schema: {
                model: {
                    fields: {
                        identityUserId: { type: "string" },
                        profilePicBase64: { type: "string" },
                        firstName: { type: "string" },
                        lastName: { type: "string" },
                        country: { type: "string" }
                    }
                }
            },
            pageSize: 10
        },
        pageable: true,
        columns: [
            {
                field: "identityUserId",
                hidden: true
            },
            {
                field: "profilePicBase64",
                title: "Profile Picture",
                width: "184px", // Set width for profile pictures
                template: `<a href="/Profile/Details?userId=#= identityUserId #"><img src='#= profilePicBase64 #' alt='Profile Picture' style='width: 50px; height: 50px; border-radius: 50%; object-fit: cover;'' /></a>`,
                sortable: false,
                filterable: false
            },
            {
                field: "firstName",
                title: "First Name",
                width: "184px", // Width for first name
                sortable: false,
                filterable: true
            },
            {
                field: "lastName",
                title: "Last Name",
                width: "184px",
                sortable: false,
                filterable: true// Width for last name
            },
            {
                field: "country",
                title: "Country",
                width: "184px",// Width for country
                sortable: false,
                filterable: true
            }
        ],
        // Set the grid container to take the full width of its parent
        height: "50vh", // Ensure that the grid adjusts dynamically
        scrollable: true, // Enable scrolling if the grid content exceeds available space
        sortable: true, // Enable global sorting
        filterable: true // Enable global filtering
    });
}