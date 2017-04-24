   
    for(aa=0;aa<window.document.body.getElementsByTagName('INPUT').length;aa++)
    {
        try {
            addListener(window.document.body.getElementsByTagName('INPUT').item(aa),'onblur',no_foco);                    
            addListener(window.document.body.getElementsByTagName('INPUT').item(aa),'onfocus',foco);                                                
            addListener(window.document.body.getElementsByTagName('INPUT').item(aa),'onkeydown',manejaOnKeyDown);                                                
            
                
            }
        catch (e) {}            
    }
    
    for(aa=0;aa<window.document.body.getElementsByTagName('SELECT').length;aa++)
    {
        try {                                                                                         
            addListener(window.document.body.getElementsByTagName('SELECT').item(aa),'onblur',no_foco);                    
            addListener(window.document.body.getElementsByTagName('SELECT').item(aa),'onfocus',foco);                                                
            addListener(window.document.body.getElementsByTagName('SELECT').item(aa),'onkeydown',manejaOnKeyDown);                                                
            
            }
        catch (e) {}
                    
     }
    for(aa=0;aa<window.document.body.getElementsByTagName('TEXTAREA').length;aa++)
    {
        try {                                                                                         
            addListener(window.document.body.getElementsByTagName('TEXTAREA').item(aa),'onblur',no_foco);                    
            addListener(window.document.body.getElementsByTagName('TEXTAREA').item(aa),'onfocus',foco);                                               
            addListener(window.document.body.getElementsByTagName('TEXTAREA').item(aa),'onkeydown',manejaOnKeyDown);                                                
            
            }
        catch (e) {}
                    
     }         
    
        for(aa=0;aa<window.document.body.getElementsByTagName('IMG').length;aa++)
    {
        try {                
            if(window.document.body.getElementsByTagName('IMG').item(aa).src.indexOf('dux.jpg')>-1){
                addListener(window.document.body.getElementsByTagName('IMG').item(aa),'onmousedown',botonDerecho);                                                                                                   
            }
            }
        catch (e) {}            
    }
    
    function foco(e) {           
        try {    
            e.srcElement.style.background = "1px solid #C5E099";            
            }
        catch (e) {}
    }

    function no_foco(e) {
        try {      
            e.srcElement.style.background = null;
            }
        catch (e) {}            
    }
     function botonDerecho(e) {
        try {      
            if(e.button!=1){
                alert('Usted se encuentra en: ' + window.document.getElementById('ctl00$enQueProgramaEstoy').value);                
                }
            }
        catch (e) {}            
    }
 
    function addListener(obj,evt,func) {
        if (obj.attachEvent)
            obj.attachEvent(evt, func);

        else {
            if (obj.addEventListener) {
                obj.addEventListener(evt,func,false);
            }
            else {
                if (obj.eval) {
                    obj[evt] = func;            
                    
                }
            }
        }
    }
    
    /********************************************************/
    /***************Manejo de pantalla general***************/
    /**********************************by ab&jw**************/    
    /********************************************************/        
    //Filtra el enter en el documento y fuerza el TAB (key=9)
    function manejaOnKeyDown (e) {
      var keycode; 
      var keycodeshift;      
      if (e) 
        {keycode = e.keyCode;
         keycodeshift = e.shiftKey;
        }
      else
        if (e) 
            keycode = e.which;
        else 
            return true;        
      if ((!keycodeshift) && (keycode == 13) )
      {             
        if((e.srcElement.type != 'image') &&(e.srcElement.type != 'submit') && (e.srcElement.type!='textarea'))
        {
            e.keyCode=9;                          
        }
      }
      else
      {
        if ((keycodeshift) && (keycode == 13))
            {
              e.keyCode=13;                         
            }
      }
    return true 
    } 

    function sacarGif()
    {
        window.onbeforeunload = null;
    }    

