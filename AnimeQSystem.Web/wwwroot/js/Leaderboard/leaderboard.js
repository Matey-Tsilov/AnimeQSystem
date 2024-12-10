export default function init() {

    $("#grid").kendoGrid({
        dataSource: {
            transport: {
                read: {
                    url: "/Leaderboard/GetLeaderboardData", // URL to your API
                    dataType: "json" // Expected data format
                }
            },
            schema: {
                model: {
                    fields: {
                        rank: { type: "number" },
                        profilePicBase64: { type: "string" },
                        firstName: { type: "string" },
                        lastName: { type: "string" },
                        country: { type: "string" },
                        userQuizzesCount: { type: "number" },
                        points: { type: "number" }
                    }
                }
            },
            pageSize: 10
        },
        pageable: true,
        columns: [
            {
                field: "rank",
                title: "Rank",
                width: "184px", // Set a specific width
                sortable: false,
                filterable: false
            },
            {
                field: "profilePicBase64",
                title: "Profile Picture",
                width: "184px", // Set width for profile pictures
                template: `<a href="/Profile/Details?userId=1"><img src='#= profilePicBase64 #' alt='Profile Picture' style='width: 50px; height: 50px; border-radius: 50%;' /></a>`,
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
            },
            {
                field: "userQuizzesCount",
                title: "Quizzes Made",
                width: "184px", // Width for quizzes made
                sortable: true,
                filterable: {
                    cell: {
                        operator: "gte" // Greater than or equal operator
                    }
                }
            },
            {
                field: "points",
                title: "Points",
                width: "184px", // Width for points
                sortable: true,
                filterable: {
                    cell: {
                        operator: "gte" // Greater than or equal operator
                    }
                }
            }
        ],
        // Set the grid container to take the full width of its parent
        height: "50vh", // Ensure that the grid adjusts dynamically
        scrollable: true, // Enable scrolling if the grid content exceeds available space
        sortable: true, // Enable global sorting
        filterable: true, // Enable global filtering
        dataBound: function () {
            var grid = this;

            // Call this function to assign ranks dynamically
            assignRanks(grid)

            // Loop through the rows and apply styles for the first 3
            markFirstPlaces(grid.tbody.find("tr"))
        }
    });
}

// Responsible for special highlighting of first 3 places
function markFirstPlaces(rows) {
    rows.each(function (index) {
        if (index === 0) {
            $(this).css({
                "background-color": "gold", // Gold background for the first row
                "border": "2px solid #FFD700" // Gold border for the first row
            });
        } else if (index === 1) {
            $(this).css({
                "background-color": "silver", // Silver background for the second row
                "border": "2px solid #C0C0C0" // Silver border for the second row
            });
        } else if (index === 2) {
            $(this).css({
                "background-color": "#cd7f32", // Bronze background for the third row
                "border": "2px solid #cd7f32" // Bronze border for the third row
            });
        }
    })
}

// Responsible for assigning different ranks dynamically on different pages
function assignRanks(grid) {
    var data = grid.dataSource.view(); // Get the current page of data
    var rankStart = (grid.dataSource.page() - 1) * grid.dataSource.pageSize(); // Adjust rank based on the page

    // Assign ranks dynamically
    for (var i = 0; i < data.length; i++) {
        var rank = rankStart + i + 1; // Calculate rank
        data[i].set("rank", rank); // Update the rank field in the data item
    }
}