<script type="text/javascript">	JotForm.newDefaultTheme = false;
	JotForm.extendsNewTheme = false;
	JotForm.singleProduct = false;
	JotForm.newPaymentUIForNewCreatedForms = false;
	JotForm.submitError="jumpToFirstError";

	JotForm.init(function(){
	/*INIT-START*/
      setTimeout(function() {
          $('input_30').hint('ex: myname@example.com');
       }, 20);

 JotForm.calendarMonths = ["January","February","March","April","May","June","July","August","September","October","November","December"];
 JotForm.calendarDays = ["Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"];
 JotForm.calendarOther = {"today":"Today"};
 var languageOptions = document.querySelectorAll('#langList li'); 
 for(var langIndex = 0; langIndex < languageOptions.length; langIndex++) { 
   languageOptions[langIndex].on('click', function(e) { setTimeout(function(){ JotForm.setCalendar("15", false, {"days":{"monday":true,"tuesday":true,"wednesday":true,"thursday":true,"friday":true,"saturday":true,"sunday":true},"future":true,"past":true,"custom":false,"ranges":false,"start":"","end":""}); }, 0); });
 } 
 JotForm.onTranslationsFetch(function() { JotForm.setCalendar("15", false, {"days":{"monday":true,"tuesday":true,"wednesday":true,"thursday":true,"friday":true,"saturday":true,"sunday":true},"future":true,"past":true,"custom":false,"ranges":false,"start":"","end":""}); });
 JotForm.formatDate({date:(new Date()), dateField:$("id_"+15)});
 JotForm.displayLocalTime("hour_15", "min_15", "ampm_15", null, false);

 JotForm.calendarMonths = ["January","February","March","April","May","June","July","August","September","October","November","December"];
 JotForm.calendarDays = ["Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"];
 JotForm.calendarOther = {"today":"Today"};
 var languageOptions = document.querySelectorAll('#langList li'); 
 for(var langIndex = 0; langIndex < languageOptions.length; langIndex++) { 
   languageOptions[langIndex].on('click', function(e) { setTimeout(function(){ JotForm.setCalendar("35", false, {"days":{"monday":true,"tuesday":true,"wednesday":true,"thursday":true,"friday":true,"saturday":true,"sunday":true},"future":true,"past":true,"custom":false,"ranges":false,"start":"","end":""}); }, 0); });
 } 
 JotForm.onTranslationsFetch(function() { JotForm.setCalendar("35", false, {"days":{"monday":true,"tuesday":true,"wednesday":true,"thursday":true,"friday":true,"saturday":true,"sunday":true},"future":true,"past":true,"custom":false,"ranges":false,"start":"","end":""}); });
 JotForm.formatDate({date:(new Date()), dateField:$("id_"+35)});
 JotForm.displayLocalTime("hour_35", "min_35", "ampm_35", null, false);
if (window.JotForm && JotForm.accessible) $('input_11').setAttribute('tabindex',0);
if (window.JotForm && JotForm.accessible) $('input_33').setAttribute('tabindex',0);
if (window.JotForm && JotForm.accessible) $('input_12').setAttribute('tabindex',0);
    if(typeof $('input_32').spinner !== 'undefined') {$('input_32').spinner({ imgPath:'https://cdn.jotfor.ms/images/', width: '60', maxValue:'', minValue:'', allowNegative: false, addAmount: 1, value:'0' });}
    $('input_32').up(2).setAttribute('tabindex','');
if (window.JotForm && JotForm.accessible) $('input_24').setAttribute('tabindex',0);
if (window.JotForm && JotForm.accessible) $('input_41').setAttribute('tabindex',0);
	/*INIT-END*/
	});

   JotForm.prepareCalculationsOnTheFly([null,{"name":"submit","qid":"1","text":"Submit Your Booking","type":"control_button"},null,null,null,null,null,null,null,null,null,{"name":"pickupAddress","qid":"11","text":"Pickup Address (Airport Or Hotel) ","type":"control_textarea"},{"name":"createYour","qid":"12","subLabel":"Here you can create your own tour with destinations and duration what you are going to stay. you can book your reservation as your wish after create tour","text":"Create Your own Customize Tour","type":"control_textarea"},null,null,{"name":"departureDatetime","qid":"15","text":"Departure Date\u002FTime  (approximately)","type":"control_datetime"},null,null,null,{"name":"vehicleType","qid":"19","subLabel":"Include with English speaking chauffeur. (French speaking guide if necessary)  ","text":"Vehicle Type","type":"control_dropdown"},null,null,null,null,{"name":"additionalMessage","qid":"24","text":"Additional Message:","type":"control_textarea"},null,null,{"name":"tourBooking","qid":"27","text":"Tour Booking Form","type":"control_head"},null,{"name":"fullName29","qid":"29","text":"Full Name","type":"control_fullname"},{"name":"email30","qid":"30","text":"E-mail","type":"control_email"},{"name":"phoneNumber31","qid":"31","text":"Phone Number","type":"control_phone"},{"name":"numberOf32","qid":"32","text":"Number of Passengers","type":"control_spinner"},{"name":"dropAddress","qid":"33","text":"Drop Address (Airport Or Hotel) ","type":"control_textarea"},{"name":"image","qid":"34","text":"Capture.5c5165df3e2f34.16676747","type":"control_image"},{"name":"returnDatetime","qid":"35","text":"Return Date\u002FTime (approximately)","type":"control_datetime"},null,{"name":"b15c523d1d4e482520090493","qid":"37","text":"car1.5c89fb94ef4fa6.30393173","type":"control_image"},null,null,{"name":"tourCode","qid":"40","text":"Tour Code","type":"control_dropdown"},{"name":"couponCode","qid":"41","subLabel":"Enter here coupon code for 10 %  off for your tour","text":"Coupon Code","type":"control_textbox"}]);
   setTimeout(function() {
JotForm.paymentExtrasOnTheFly([null,{"name":"submit","qid":"1","text":"Submit Your Booking","type":"control_button"},null,null,null,null,null,null,null,null,null,{"name":"pickupAddress","qid":"11","text":"Pickup Address (Airport Or Hotel) ","type":"control_textarea"},{"name":"createYour","qid":"12","subLabel":"Here you can create your own tour with destinations and duration what you are going to stay. you can book your reservation as your wish after create tour","text":"Create Your own Customize Tour","type":"control_textarea"},null,null,{"name":"departureDatetime","qid":"15","text":"Departure Date\u002FTime  (approximately)","type":"control_datetime"},null,null,null,{"name":"vehicleType","qid":"19","subLabel":"Include with English speaking chauffeur. (French speaking guide if necessary)  ","text":"Vehicle Type","type":"control_dropdown"},null,null,null,null,{"name":"additionalMessage","qid":"24","text":"Additional Message:","type":"control_textarea"},null,null,{"name":"tourBooking","qid":"27","text":"Tour Booking Form","type":"control_head"},null,{"name":"fullName29","qid":"29","text":"Full Name","type":"control_fullname"},{"name":"email30","qid":"30","text":"E-mail","type":"control_email"},{"name":"phoneNumber31","qid":"31","text":"Phone Number","type":"control_phone"},{"name":"numberOf32","qid":"32","text":"Number of Passengers","type":"control_spinner"},{"name":"dropAddress","qid":"33","text":"Drop Address (Airport Or Hotel) ","type":"control_textarea"},{"name":"image","qid":"34","text":"Capture.5c5165df3e2f34.16676747","type":"control_image"},{"name":"returnDatetime","qid":"35","text":"Return Date\u002FTime (approximately)","type":"control_datetime"},null,{"name":"b15c523d1d4e482520090493","qid":"37","text":"car1.5c89fb94ef4fa6.30393173","type":"control_image"},null,null,{"name":"tourCode","qid":"40","text":"Tour Code","type":"control_dropdown"},{"name":"couponCode","qid":"41","subLabel":"Enter here coupon code for 10 %  off for your tour","text":"Coupon Code","type":"control_textbox"}]);}, 20); 
</script>