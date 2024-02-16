// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ajax_post_form() {
  console.log('ajax_post_form');

  const form_data = new FormData();
  form_data.append('Name', 'John');
  form_data.append('Age', 30);

  const arr = [1,2,3,4]
  // FormData 要傳 array 只能先轉成 JSON 字串，接收端再處理轉回 array
  form_data.append('JsonArr', JSON.stringify(arr));
  
  $.ajax({
    url: '/Home/AjaxPostForm',
    type: 'POST',
    data: form_data,
    contentType: false,
    processData: false,
    success: function(data){
      console.log(data);
    }
  });
}

function ajax_post_json() {
  console.log('ajax_post_json');

  const dataJSON = {
    Name: 'John',
    Age: 30,
    JsonArr: [1,2,3,4]
  }

  $.ajax({
    url: '/Home/AjaxPostJson',
    type: 'POST',
    data: JSON.stringify(dataJSON),
    contentType: "application/json;charset=utf-8",
    success: function(data){
      console.log(data);
    }
  });
}