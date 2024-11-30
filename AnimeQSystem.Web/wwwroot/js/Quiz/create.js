function init() {
    document.getElementById("createAnotherQuestion").addEventListener("click", addQuestion)
    document.getElementById("createQuizForm").addEventListener("submit", validateFields)

    // Add event listener for right helper section which also appends the other event listeners to the generated elements
    Array.from(document.querySelectorAll(".question-container select"))
        .forEach(el => el.addEventListener("change", toggleQuestionOptionsHelper));

    // Add event listeners to already existing opened right helper sections for true/false questions
    const trueFalseOptions = Array.from(document.querySelectorAll(".is-true, .is-false"));
    trueFalseOptions.forEach(opt => opt.addEventListener("click", selectCorrectOptionTrueFalse));

    // Add event listeners to multiple choice options, to not be able to select many radio buttons
    const multipleUniqueChoiceQuestions = Array.from(new Set([...document.querySelectorAll('input[type="radio"]')].map(el => el.parentElement.parentElement.parentElement.parentElement)));
    multipleUniqueChoiceQuestions.forEach(q => allowOneRadionButtonSelectedAtATime(q));

    // Add event listeners to all write own answer questions to change the question answer accordingly???????????????
    const writeOwnAnswerQuestions = Array.from(document.querySelectorAll(".write-answer"));
    writeOwnAnswerQuestions.forEach(q => q.querySelector(".form-control").addEventListener("change", (e) => q.parentElement.querySelector(`input[name$=".Answer"]`).value = e.target.value))

    // Add event listener to all delete buttons which are pre-populated on error return
    const deleteQuestionButtons = Array.from(document.querySelectorAll(".sideways-delete-btn"));
    deleteQuestionButtons.forEach(b => b.addEventListener("click", (e) => e.target.parentElement.parentElement.remove()));
}

// Keep track with closure how many questions are there
// Function to add another question to the quiz
let questionCount = 1;
function addQuestion() {

    const exampleEl = document.getElementById("question_0");

    // Create delete btn for each new question
    const deleteBtnString = `<span id="deleteQuestion_${questionCount}" class="text-danger fw-bold sideways-delete-btn" style="font-size: 1.5rem;">&times;</span>`
    const tempDiv = document.createElement('div');
    tempDiv.innerHTML = deleteBtnString;
    const deleteBtnEl = tempDiv.firstChild;

    // Clone the node deeply (including child elements)
    const newQuestion = exampleEl.cloneNode(true);

    // Update name attributes of the input and others
    newQuestion.id = `question_${questionCount}`;
    newQuestion.querySelector('.form-floating label').setAttribute('for', `QuizQuestions[${questionCount}].Title`);
    newQuestion.querySelector('.form-floating input').setAttribute('name', `QuizQuestions[${questionCount}].Title`);
    newQuestion.querySelector('.form-floating span').setAttribute('data-valmsg-for', `QuizQuestions[${questionCount}].Title`);
    newQuestion.querySelector('.form-floating span').innerHTML = ''; // Clear errors if there were any
    newQuestion.querySelector('.form-floating input').value = ''; // Clear the input value
    // Update the attributes on the select
    newQuestion.querySelector('.form-input span').setAttribute('data-valmsg-for', `QuizQuestions[${questionCount}].QuizType`);
    newQuestion.querySelector('.form-input select').setAttribute('name', `QuizQuestions[${questionCount}].QuizType`);
    newQuestion.querySelector('.form-input select').value = '0'; // Clear the input value
    // Clear the quiz answer input
    newQuestion.querySelector('.form-input input').setAttribute('name', `QuizQuestions[${questionCount}].Answer`); 
    newQuestion.querySelector('.form-input input').value = ''; // Clear the input value
    // Update id of options helper and clear the tab
    newQuestion.querySelector('.sideways-helper-menu').innerHTML = '';
    newQuestion.querySelector('.sideways-helper-menu').id = `question_${questionCount}_optionHelper`;

    // Append the eventListener for select change
    newQuestion.querySelector('.form-input select').addEventListener("change", toggleQuestionOptionsHelper);

    // Add the delete button with its functionality
    newQuestion.appendChild(deleteBtnEl);
    newQuestion.querySelector(`#deleteQuestion_${questionCount}`).addEventListener("click", () => newQuestion.remove());

    // Append the cloned question to the container
    document.getElementById('quizQuestionCreation').insertBefore(newQuestion, document.getElementById("addQuestionAndCreateQuizButtons"));

    questionCount++;
}

// By default in HTML radio buttons with the same name
// can be selected one at a time, this functions is for cases where
// they don't share the same name
function allowOneRadionButtonSelectedAtATime(container) {
    const radioButtons = container.querySelectorAll('input[type="radio"]');

    // Loop through each radio button and add event listener
    radioButtons.forEach(radio => {
        radio.addEventListener('click', function () {
            // When one radio button is clicked, uncheck the others
            radioButtons.forEach(otherRadio => {
                if (otherRadio !== radio) {
                    otherRadio.checked = false;
                }
            });

            // Change value of question answer upon select
            const allOptions = Array.from(radio.parentElement.parentElement.parentElement.querySelectorAll(".form-control"));
            const optionNumber = radio.parentElement.id.split("_")[1];
            const selectedValue = allOptions[optionNumber].value
            const questionNumber = container.parentElement.id.split("_")[1];
            container.parentElement.querySelector(`[name="QuizQuestions[${questionNumber}].Answer"]`).value = selectedValue;
        });
    });
}

// Function to toggle classes of selected buttons 
// and append correct value to hidden input
function selectCorrectOptionTrueFalse(e) {

    switch (e.target.textContent) {
        case "True":

            // We have a toggle class functionality to stimulate selected button
            if (e.target.classList.contains("btn-outline-success")) {
                e.target.classList.remove("btn-outline-success");
                e.target.classList.add("btn-success");

                // Also nullify the state of the other option, if selected
                e.target.nextElementSibling.classList.remove("btn-danger");
                e.target.nextElementSibling.classList.add("btn-outline-danger");
            } else {
                e.target.classList.add("btn-outline-success");
                e.target.classList.remove("btn-success");
            }
            break

        case "False":

            // We have a toggle class functionality to stimulate selected button
            if (e.target.classList.contains("btn-outline-danger")) {
                e.target.classList.remove("btn-outline-danger");
                e.target.classList.add("btn-danger");

                // Also nullify the state of the other option, if selected
                e.target.previousElementSibling.classList.remove("btn-success");
                e.target.previousElementSibling.classList.add("btn-outline-success");
            } else {
                e.target.classList.add("btn-outline-danger");
                e.target.classList.remove("btn-danger");
            }
            break
    }

    // Assign the same value on button click as the question's Answer
    const questionN = e.target.parentElement.parentElement.id.split("_")[1];
    const answerSelector = `[name="QuizQuestions[${questionN}].Answer"]`;
    e.target.parentElement.parentElement.parentElement.querySelector(answerSelector).value = e.target.textContent.toLowerCase();
}

// Responsible for appearing on the left of all options
// for the different question types
function toggleQuestionOptionsHelper(e) {

    const questionTypeSelectValue = e.target.value;
    const questionNumber = Number(e.target.parentElement.parentElement.id.split("_")[1]);
    const questionOptionHelper = document.getElementById(`question_${questionNumber}_optionHelper`);

    // Different options for the optionsHelper templates
    const optionTrueOrFalse = `
    <div class="form-floating d-flex flex-column gap-2">
        <button class="btn btn-outline-success is-true" type="button">True</button>
        <button class="btn btn-outline-danger is-false" type="button">False</button>
    </div>`;

    const optionMultipleChoice = `
    <div class="form-floating d-flex gap-2" style="width:300px;">
        <div class="d-flex flex-column gap-2">
            <div class="form-floating d-flex gap-1" id="optionText_0">
                <input name="QuizQuestions[${questionNumber}].QuizOptions[0].OptionText" class="form-control" placeholder="Option &#8470;1" required/>
                <label for="QuizQuestions[${questionNumber}].QuizOptions[0].OptionText" class="form-label">Option &#8470;1</label>
                <input name="QuizQuestions[${questionNumber}].QuizOptions[0].IsCorrect" type="radio" value="true"/>
            </div>
            <div class="form-floating d-flex gap-1" id="optionText_1">
                <input name="QuizQuestions[${questionNumber}].QuizOptions[1].OptionText" class="form-control" placeholder="Option &#8470;2" required/>
                <label for="QuizQuestions[${questionNumber}].QuizOptions[1].OptionText" class="form-label">Option &#8470;2</label>
                <input name="QuizQuestions[${questionNumber}].QuizOptions[1].IsCorrect" type="radio" value="true"/>
            </div>
        </div>
        <div class="d-flex flex-column gap-2">
            <div class="form-floating d-flex gap-1" id="optionText_2">
                <input name="QuizQuestions[${questionNumber}].QuizOptions[2].OptionText" class="form-control" placeholder="Option &#8470;3" required/>
                <label for="QuizQuestions[${questionNumber}].QuizOptions[2].OptionText" class="form-label">Option &#8470;3</label>
                <input name="QuizQuestions[${questionNumber}].QuizOptions[2].IsCorrect" type="radio" value="true"/>
            </div>
            <div class="form-floating d-flex gap-1" id="optionText_3">
                <input name="QuizQuestions[${questionNumber}].QuizOptions[3].OptionText" class="form-control" placeholder="Option &#8470;4" required/>
                <label for="QuizQuestions[${questionNumber}].QuizOptions[3].OptionText" class="form-label">Option &#8470;4</label>
                <input name="QuizQuestions[${questionNumber}].QuizOptions[3].IsCorrect" type="radio" value="true"/>
            </div>
        </div>
    </div>`;

    const optionWriteAnswer = `
    <div class="form-floating" style="width:200px;">
        <input name="QuizQuestions[${questionNumber}].QuizOptions[0].OptionText" class="form-control" placeholder="Your Answer" required/>
        <label for="QuizQuestions[${questionNumber}].QuizOptions[0].OptionText" class="form-label">Your Answer</label>
        <input name="QuizQuestions[${questionNumber}].QuizOptions[0].IsCorrect" class="d-none" value="True"/>
    </div>`;

    switch (questionTypeSelectValue) {
        case "0":
            questionOptionHelper.classList.add("d-none");
            questionOptionHelper.innerHTML = "";
            break;
        case "1":
            questionOptionHelper.classList.remove("d-none");
            questionOptionHelper.innerHTML = optionTrueOrFalse;

            // Add an event to select the corresponding option
            const options = Array.from(questionOptionHelper.querySelectorAll("button"));
            options.forEach(opt => opt.addEventListener("click", selectCorrectOptionTrueFalse));
            break;
        case "2":
            questionOptionHelper.classList.remove("d-none");
            questionOptionHelper.innerHTML = optionMultipleChoice;
            allowOneRadionButtonSelectedAtATime(questionOptionHelper);
            break;
        case "3":
            questionOptionHelper.classList.remove("d-none");
            questionOptionHelper.innerHTML = optionWriteAnswer;
            questionOptionHelper.querySelector(".form-control").addEventListener("change",
                (e) => questionOptionHelper.parentElement.querySelector(`[name="QuizQuestions[${questionNumber}].Answer"]`).value = e.target.value)
            break;
    }
}

// This will include custom logic before sending the request
// if the input doesn't meet the requirements the request will be stopped and
// an alert will be shown
function validateFields(e) {

    // validate that all OptionTexts have value - not an empty string
    const allOptionsTextsSelector = Array.from(e.target.querySelectorAll('input[name$=".OptionText"]'))
    const allOptionTextsHaveText = (allOptionsTextsSelector).every(x => x.value.trim() != "");

    const allQuestionsAnswersSelector = Array.from(e.target.querySelectorAll('input[name$=".Answer"]'))
    const allQuestionsHaveValidAnswers = (allQuestionsAnswersSelector).every(x => x.value.trim() != "");

    if (allOptionsTextsSelector.length > 0 && !allOptionTextsHaveText) {
        alert("Make sure that all of your question options have text!")
        e.preventDefault();
    }
    else if (allQuestionsAnswersSelector.length > 0 && !allQuestionsHaveValidAnswers) {
        alert("Make sure that all of your question have marked answers!")
        e.preventDefault();
    }
}

export default { init }
