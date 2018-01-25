function GetMessage(lNode) {
	if (lNode.hasChildNodes()) {
		var text = [];
		for (i = 0; i < lNode.childNodes.length; i++) {
			text.push(lNode.childNodes[i].textContent);
		}
		return text.join("");
	} else {
		return lNode.innerHTML;
	}
}

function SetupListeners() {
	var target = document.getElementById('js_1');
	var nodes = target.querySelectorAll('._aok > span._3oh-');
	var links;
	var lastTxt = GetMessage(nodes[nodes.length - 1]);

	var observer = new MutationObserver(function (mutations) {
		nodes = target.querySelectorAll('._aok > span._3oh-');

		var lastNode = nodes[nodes.length - 1];

		var msg = GetMessage(lastNode);
		
		var pics = target.querySelectorAll('._4ld- > img');
		var name = pics[pics.length - 1].getAttribute('alt');
		if (msg !== lastTxt) {
			if (pics.length > 0) {
				window.external.ProcessMessage(msg, name, pics[0].innerHTML);
			} else {
				window.external.ProcessMessage(msg, name);
			}
		}
	});

	var config = { subtree: true, childList: true, characterData: true };
	observer.observe(target, config);
}