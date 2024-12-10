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
                        profilePic: { type: "string" },
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
        sortable: true,
        filterable: true,
        columns: [
            {
                field: "rank",
                title: "Rank",
                width: 70, // Set a specific width
                filterable: false
            },
            {
                field: "profilePic",
                title: "Profile Picture",
                width: 100, // Set width for profile pictures
                template: `<img src='#= profilePic #' alt='Profile Picture' style='width: 50px; height: 50px;' />`,
                filterable: false
            },
            {
                field: "firstName",
                title: "First Name",
                width: 150 // Width for first name
            },
            {
                field: "lastName",
                title: "Last Name",
                width: 150 // Width for last name
            },
            {
                field: "country",
                title: "Country",
                width: 120 // Width for country
            },
            {
                field: "userQuizzesCount",
                title: "Quizzes Made",
                width: 120, // Width for quizzes made
                filterable: {
                    cell: {
                        operator: "gte" // Greater than or equal operator
                    }
                }
            },
            {
                field: "points",
                title: "Points",
                width: 100, // Width for points
                filterable: {
                    cell: {
                        operator: "gte" // Greater than or equal operator
                    }
                }
            }
        ]
    });
}