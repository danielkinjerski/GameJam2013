﻿package  {
	
	import flash.display.MovieClip;
	import flash.events.Event;
	import flash.text.TextField;
	import flash.external.ExternalInterface;
	
	
	public class TutorialMenu extends MovieClip {
		
		
		public var sourceText:TextField;
		public var tutorialText:TextField;
		public const timeBetweenLetters:Number = 50/*miliiseconds*/;
		public const timeBetweenFrames:Number = 1000/*miliiseconds*/;
		private var prevTime:Date;
		private var newDate:Date;
		private var sourceIndex:int = 1;
		private var textIndex:int = 0;
		private var timeDelta:Number;
		private var tempString:String;
		private var sourceComplete:Boolean = false;
		private var tutorialComeplete:Boolean = false;
		
		public function TutorialMenu() {
			// constructor code
			this.addEventListener(Event.ENTER_FRAME, Update);
			sourceText = getChildByName("txt_source_" + sourceIndex.toString())as TextField;
			tutorialText = getChildByName("txt_tutorial") as TextField;
			tutorialText.text = "";
			prevTime = new Date();
		}
		
		public function Update(e:Event)
		{
			if (!tutorialComeplete)
			{
				newDate = new Date();
				timeDelta =newDate.getTime() - prevTime.getTime();
				
				 if (!sourceComplete)
				 {
					if (timeDelta >= timeBetweenLetters)
					{
						if ((sourceText.text.length-1) > textIndex)
						{
							tempString = sourceText.text.substring(textIndex, textIndex+1);	
							tutorialText.appendText(tempString);
							textIndex++;
						}
						else
						{
							sourceComplete = true;
						}
						prevTime = newDate;
					}
				 }
				 else
				 {
					 if (timeDelta >= timeBetweenFrames)
					 {
						 NextStep();
						 prevTime = newDate;
					 }
				 }
			}
			else
			{
				this.removeEventListener(Event.ENTER_FRAME, Update);
			}
			
		}
		
		public function AddLetterToTutorialText()
		{
			
		}
		
		public function NextStep()
		{
			tutorialText.text = "  ";
			sourceIndex ++;
			textIndex = 0;
			sourceComplete = false;
			sourceText= getChildByName("txt_source_" + sourceIndex.toString()) as TextField;
			if (sourceText == null)
			{
				tutorialComeplete = true;
			}
		}
		
		public function TutorialComplete()
		{
			this.visible = false;
			ExternalInterface.call("TutorialComplete");
		}
	}
	
}
