// Step 1: Select elements
let input = document.getElementById("taskInput");
let addBtn = document.getElementById("addBtn");
let taskList = document.getElementById("taskList");

// Step 2: Add event listener to button
addBtn.addEventListener("click", function () {
  let taskText = input.value.trim();

  if (taskText !== "") {
    // Step 3: Create new list item
    let li = document.createElement("li");
    li.textContent = taskText;

    // Step 4: Add click event to mark as done
    li.addEventListener("click", function () {
      li.classList.toggle("done");
    });

    // Step 5: Append to list
    taskList.appendChild(li);

    // Step 6: Clear input
    input.value = "";
  }
});
