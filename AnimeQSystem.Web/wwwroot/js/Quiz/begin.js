export default function init() {
    document.getElementById("backBtn").addEventListener("click", () => goToPage("back"));
    document.getElementById("nextBtn").addEventListener("click", () => goToPage("next"));
    document.getElementById("submitBtn").addEventListener("submit", validateInput);

    // Attach the changing of the progress bar to each input answer change
    document.querySelectorAll('input[name$="YourAnswer"]').forEach(ya => ya.addEventListener("change", updateQuestionProgressBar));

    // Add event listener to all options inputs to automatically change the question answer input
    document.querySelectorAll('.option input[type="radio"]').forEach(opt => opt.addEventListener("change", changeQuestionAnswerInput));
}

const allQuestions = Array.from(document.querySelectorAll(".question"));
let currentPage = 0;

// Responsible for hiding and showing correct question number
function goToPage(direction) {

    // Different cases with different directions
    const previousPage = currentPage - 1;
    const nextPage = currentPage + 1;

    // Indicator for page number change
    const isUp = direction == "next";

    // Change visibility
    allQuestions[currentPage].classList.add("d-none");
    allQuestions[isUp ? nextPage : previousPage].classList.remove("d-none");

    // Depending on direction change page number tracker
    isUp ? currentPage++ : currentPage--;

    updateQuestionCounter();
    updateMoveBtnsContainer();
}

// Responsible for updating the counter on each page change backward or forward
function updateQuestionCounter() {
    const counter = document.getElementById("questionCounter");

    counter.textContent = `(${currentPage + 1} of ${allQuestions.length})`;        
}

// Responsible for updating the progress bar on each answer marked
function updateQuestionProgressBar() {

    // Different types of input have different types of value also so we need a way to check both types' count
    const allAnsweredMCandWAQuestionsCount = Array.from(document.querySelectorAll(`input[name$=".YourAnswer"]:not([type="radio"])`)).filter(el => el.value.trim() != "").length;
    const allAnsweredTrueFalseQuestionsCount = Array.from(document.querySelectorAll(`input[name$="Answer"][type="radio"]`)).filter(el => el.checked).length;
    const allAnsweredCount = allAnsweredMCandWAQuestionsCount + allAnsweredTrueFalseQuestionsCount;

    const progressBar = document.querySelector("#quizProgressBar .progress-bar");
    const step = 100 / allQuestions.length

    progressBar.style.width = step * allAnsweredCount + '%';
    progressBar.textContent = step * allAnsweredCount + '%';
}

// Responsible for updating the inside of the container with the move buttons
function updateMoveBtnsContainer() {
    const backBtn = document.getElementById("backBtn");
    const nextBtn = document.getElementById("nextBtn");
    const submitBtn = document.getElementById("submitBtn");

    // Handle back button visibility
    if (currentPage != 0) {

        backBtn.classList.remove("d-none");
        backBtn.disabled = false;

    } else {

        backBtn.classList.add("d-none");
        backBtn.disabled = true;
    }

    // Handle next and submit buttons visibility
    if (currentPage + 1 == allQuestions.length) {

        nextBtn.classList.add("d-none");
        nextBtn.disabled = true;
        submitBtn.classList.remove("d-none");
        submitBtn.disabled = false;

    } else {

        nextBtn.classList.remove("d-none");
        nextBtn.disabled = false;
        submitBtn.classList.add("d-none");
        submitBtn.disabled = true;
    }
}

// Responsible for building connection between isChosen for question option and the question answer
function changeQuestionAnswerInput(e) {

    // Get the chosen value
    const chosenOptionText = e.target.nextElementSibling.textContent;

    // Change the corresponding answer value
    const answerInput = e.target.parentElement.parentElement.parentElement.querySelector('input[type="text"]');
    answerInput.value = chosenOptionText;

    // Manually trigger the 'change' event
    const event = new Event('change', { bubbles: true });
    answerInput.dispatchEvent(event);
}

// Make some final checks before allowing the user to submit his answers
function validateInput(e) {
    const progressbarProcentage = Number(document.querySelector(".progress-bar").textContent.split("%")[0]);

    if (progressbarProcentage != 100) {
        alert("You first need to give an answer to all questions!");
        e.preventDefault();
    }
}