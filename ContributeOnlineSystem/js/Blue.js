// JScript source code
(function(){

    //Blue�����ռ�
    if(!window.blue){
        window['Blue'] = {};
    }
        
    /*����Ƿ�֧��һЩ���Է���*/
    function IsCompatible(other){
        if(other == false || !Array.prototype.push || !Object.prototype || !document.createElement || !document.getElementsByTagName)
        { return false;}
        
        return true;
    }
    window['Blue']['IsCompatible'] = IsCompatible;

    
    /*ͨ��id��ȡ�Ķ�Ӧ��������� ֧�ֶ������ ������������*/
    //�뺯��getElementById()���ܴ�����ͬ����$�������Բ�ѯ���Ԫ��
    //�磺$('id1','id2','id3')
    function $()
    {
        var elements = new Array();
        
        //���Ҳ����ṩ������Ԫ��
        for(var i=0;i<arguments.length;i++)
        {
            var element = arguments[i];
            
            //����ò�����һ���ַ��� ��Ϊ����һ��id
            if(typeof element == 'string')
            {
                element = document.getElementById(element);
            }
            
            //�������ֻ��һ�� ��ʹ��elements���� ֱ�ӷ���element
            if(arguments.length == 1)
            {
                return element;
            }
            else
            {
                elements.push(element); 
            }
        }
        
        return elements;
    }
    window['Blue']['$'] = $;
    
    
    /*��һ���ڵ���� һ����Ӧ���¼���������*/
    function AddEvent(node,type,listener)
    {
       // if(IsCompatible() == false){return false} //�Ƿ����
        
        if( !(node = $(node)) ) {return false;}
        
        if(node.addEventListener) //֧��W3C����
        {
            node.addEventListener(type,listener,false);
            return true;
        }
        else if(node.attachEvent) //֧��MSIE
        {
            node['e' + type + listener ] = listener;
            node[type + listener] = function(){ node['e' + type + listener ](window.event); }
            
            node.attachEvent('on'+type,node[type + listener]);
            return true;
        }
        else{ return false;}
    }
    window['Blue']['AddEvent'] = AddEvent;
    
    
    /*�Ƴ�ָ���ڵ�� ָ�����͵� �¼���������*/
    function removeEvent(node,type,listener)
    {
        if( !(node = $(node)) ) {return false;}
        
        if(node.removeEventlistener) //֧��W3C����
        {
           node.removeEventlistener(type,listener,false);
           return true;
        }
        else if(node.detachEvent)
        {
            node.detachEvent('on'+type,node[type + listener]);
            node[type + listener] = null;
            return true;
        }
        else{ return false;}
    }
    window['Blue']['removeEvent'] = removeEvent;
    
    /*��������ѯ����*/
    function getElementsByClassName(className,tag,parent)
    {
        parent = parent||document;
        
        if(!(parent = $(parent))) {return false;}
        
        //��������ƥ��ı�ǩ
        var allTags = (tag == "*" && parent.all)?   parent.all:  parent.getElementsByTagName(tag);
        var matchingElements = new Array();
        
        //����һ��������ʽ
        className = className.replace(/\-/g,"\\-");
        var regex = new RegExp("(^|\\s)" + className + "(\\s|$)");
        
        var element;
        
        //���ÿ��Ԫ��
        for(var i=0;i<allTags.length;i++){
            element = allTags[i];
            if(regex.test(element.className)){
               matchingElements.push(element);
            }
        }
        //�����κ�ƥ���Ԫ��
        return matchingElements;
    }
    window['Blue']['getElementsByClassName'] = getElementsByClassName;
    
    /*�л�DOM����Ԫ�صĿɼ���*/
    function toggleDispaly(node,value)
    {
        if( !(node = $(node)) ) {return false;}
        
        if(node.style.dispaly != 'none')
        {
            node.style.dispaly = 'none';
        }
        else
        {
            node.style.dispaly = vule || '';
        }
        return true;
    }
    window['Blue']['toggleDispaly'] = toggleDispaly;
    
    
    /*��һ������֮�����һ����Ӧ�Ķ���*/
    function insertAfter(node,referenceNode)
    {
        if(!(node = $(node))) return false; 
                //nodeΪ����ʱ����Ƿ���� nodeΪ�ַ���ʱ$�����ɷ���node��Ӧ�Ķ���
        
        if(!(referenceNode = $(referenceNode))) return false;
        
        return referenceNode.parentNode.insertBefore(node,referenceNode.nextSibling);
                //referenceNode.parentNode���ڵ����insertBefore�����ӽڵ�referenceNode����һ���ڵ�    
    }
    window['Blue']['insertAfter'] = insertAfter;
    
    
    /*�Ƴ�һ���ӽڵ�*/
    function removeChildren(parent)
    {
        if(!(parent = $(parent))) return false;
        
        while(parent.firstChild)
        {
            parent.removeChild(parent.firstChild);
        }
        return parent;
    }
    window['Blue']['removeChildren'] = removeChildren;
    
    
    /*�󶨺���������ָ���Ķ���*/
    function bindFunction(obj,func)
    {
        return function()
        {
            func.apply(obj,arguments);
        };
    } 
    window['Blue']['bindFunction'] = bindFunction;
    
    
   /*��ȡ���ڴ�С*/
   function getBrowserWindowSize()
   {
        var de = document.documentElement;
        return {
            'width':(window.innerWidth||( de && de.clientWidth )|| document.body.clientWidth ),
            'height':(window.innerHeight||( de && de.clientHeight )|| document.body.clientHeight)
            };
   }
   window['Blue']['getBrowserWindowSize'] = getBrowserWindowSize;
   
}

)();