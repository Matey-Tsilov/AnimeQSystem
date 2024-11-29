function init() {
    document.getElementById("createAnotherQuestion").addEventListener("click", addQuestion)
    document.querySelector("select[name='QuizQuestions[0].QuizType']").addEventListener("change", toggleQuestionOptionsHelper)
}

function addQuestion() {

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
        });
    });
}

// Function to toggle classes of selected buttons 
// and append correct value to hidden input
function selectCorrectOptionTrueFalse(e) {

    switch (e.target.textContent) {
        case "True":
            e.target.parentElement.querySelector("input").value = true;

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
            e.target.parentElement.querySelector("input").value = false;

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
}

function toggleQuestionOptionsHelper(e) {

    const questionTypeSelectValue = e.target.value;
    const questionNumber = Number(e.target.parentElement.parentElement.id.split("_")[1]);
    const questionOptionHelpers = Array.from(document.getElementsByClassName("quizOptionHelper"))[questionNumber];

    // Different options for the optionsHelper templates
    const optionTrueOrFalse = `
    <div class="form-floating d-flex flex-column gap-2">
        <button class="btn btn-outline-success" type="button">True</button>
        <button class="btn btn-outline-danger" type="button">False</button>
        <input name="QuizQuestions[${questionNumber}].QuizOptions[0].IsCorrect" class="d-none" />
    </div>`;

    const optionMultipleChoice = `
    <div class="form-floating d-flex gap-2" style="width:300px;">
        <div class="d-flex flex-column gap-2">
            <div class="form-floating d-flex gap-1" id="optionText_0">
                <input name="QuizQuestions[${questionNumber}].QuizOptions[0].OptionText" class="form-control" placeholder="Option &#8470;1"/>
                <label for="QuizQuestions[${questionNumber}].QuizOptions[0].OptionText" class="form-label">Option &#8470;1</label>
                <span class="text-danger" id="QuizQuestions[${questionNumber}].QuizOptions[0].OptionText_error"></span>
                <input name="QuizQuestions[${questionNumber}].QuizOptions[0].IsCorrect" type="radio"/>
            </div>
            <div class="form-floating d-flex gap-1" id="optionText_1">
                <input name="QuizQuestions[${questionNumber}].QuizOptions[1].OptionText" class="form-control" placeholder="Option &#8470;2" />
                <label for="QuizQuestions[${questionNumber}].QuizOptions[1].OptionText" class="form-label">Option &#8470;2</label>
                <span class="text-danger" id="QuizQuestions[${questionNumber}].QuizOptions[1].OptionText_error"></span>
                <input name="QuizQuestions[${questionNumber}].QuizOptions[1].IsCorrect" type="radio"/>
            </div>
        </div>
        <div class="d-flex flex-column gap-2">
            <div class="form-floating d-flex gap-1" id="optionText_2">
                <input name="QuizQuestions[${questionNumber}].QuizOptions[2].OptionText" class="form-control" placeholder="Option &#8470;3" />
                <label for="QuizQuestions[${questionNumber}].QuizOptions[2].OptionText" class="form-label">Option &#8470;3</label>
                <span class="text-danger" id="QuizQuestions[${questionNumber}].QuizOptions[2].OptionText_error"></span>
                <input name="QuizQuestions[${questionNumber}].QuizOptions[2].IsCorrect" type="radio"/>
            </div>
            <div class="form-floating d-flex gap-1" id="optionText_3">
                <input name="QuizQuestions[${questionNumber}].QuizOptions[3].OptionText" class="form-control" placeholder="Option &#8470;4" />
                <label for="QuizQuestions[${questionNumber}].QuizOptions[3].OptionText" class="form-label">Option &#8470;4</label>
                <span class="text-danger" id="QuizQuestions[${questionNumber}].QuizOptions[3].OptionText_error"></span>
                <input name="QuizQuestions[${questionNumber}].QuizOptions[3].IsCorrect" type="radio"/>
            </div>
        </div>
    </div>`;

    const optionWriteAnswer = `
    <div class="form-floating" style="width:200px;">
        <input name="QuizQuestions[${questionNumber}].QuizOptions[0].OptionText" class="form-control" placeholder="Your Answer" />
        <label for="QuizQuestions[${questionNumber}].QuizOptions[0].OptionText" class="form-label">Your Answer</label>
        <span class="text-danger" id="QuizQuestions[${questionNumber}].QuizOptions[0].OptionText_error"></span>
        <input name="QuizQuestions[${questionNumber}].QuizOptions[0].IsCorrect" class="d-none" value="True"/>
    </div>`;

    switch (questionTypeSelectValue) {
        case "":
            questionOptionHelpers.classList.add("d-none");
            questionOptionHelpers.innerHTML = "";
            break;
        case "0":
            questionOptionHelpers.classList.remove("d-none");
            questionOptionHelpers.innerHTML = optionTrueOrFalse;

            // Add an event to select the corresponding option
            const options = Array.from(questionOptionHelpers.querySelectorAll("button"));
            options.forEach(opt => opt.addEventListener("click", selectCorrectOptionTrueFalse));
            break;
        case "1":
            questionOptionHelpers.classList.remove("d-none");
            questionOptionHelpers.innerHTML = optionMultipleChoice;
            allowOneRadionButtonSelectedAtATime(questionOptionHelpers);
            break;
        case "2":
            questionOptionHelpers.classList.remove("d-none");
            questionOptionHelpers.innerHTML = optionWriteAnswer;
            break;
    }
}

export default { init }
