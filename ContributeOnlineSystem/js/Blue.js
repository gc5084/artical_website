// JScript source code
(function(){

    //Blue命名空间
    if(!window.blue){
        window['Blue'] = {};
    }
        
    /*检查是否支持一些属性方法*/
    function IsCompatible(other){
        if(other == false || !Array.prototype.push || !Object.prototype || !document.createElement || !document.getElementsByTagName)
        { return false;}
        
        return true;
    }
    window['Blue']['IsCompatible'] = IsCompatible;

    
    /*通过id获取的对应对象的引用 支持多个参数 返回引用数组*/
    //与函数getElementById()功能大致相同，但$函数可以查询多个元素
    //如：$('id1','id2','id3')
    function $()
    {
        var elements = new Array();
        
        //查找参数提供的所有元素
        for(var i=0;i<arguments.length;i++)
        {
            var element = arguments[i];
            
            //如果该参数是一个字符串 认为它是一个id
            if(typeof element == 'string')
            {
                element = document.getElementById(element);
            }
            
            //如果参数只有一个 则不使用elements数组 直接返回element
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
    
    
    /*向一个节点添加 一个相应的事件监听函数*/
    function AddEvent(node,type,listener)
    {
       // if(IsCompatible() == false){return false} //是否兼容
        
        if( !(node = $(node)) ) {return false;}
        
        if(node.addEventListener) //支持W3C方法
        {
            node.addEventListener(type,listener,false);
            return true;
        }
        else if(node.attachEvent) //支持MSIE
        {
            node['e' + type + listener ] = listener;
            node[type + listener] = function(){ node['e' + type + listener ](window.event); }
            
            node.attachEvent('on'+type,node[type + listener]);
            return true;
        }
        else{ return false;}
    }
    window['Blue']['AddEvent'] = AddEvent;
    
    
    /*移除指定节点的 指定类型的 事件监听函数*/
    function removeEvent(node,type,listener)
    {
        if( !(node = $(node)) ) {return false;}
        
        if(node.removeEventlistener) //支持W3C方法
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
    
    /*安类名查询对象*/
    function getElementsByClassName(className,tag,parent)
    {
        parent = parent||document;
        
        if(!(parent = $(parent))) {return false;}
        
        //查找所有匹配的标签
        var allTags = (tag == "*" && parent.all)?   parent.all:  parent.getElementsByTagName(tag);
        var matchingElements = new Array();
        
        //创建一个正则表达式
        className = className.replace(/\-/g,"\\-");
        var regex = new RegExp("(^|\\s)" + className + "(\\s|$)");
        
        var element;
        
        //检查每个元素
        for(var i=0;i<allTags.length;i++){
            element = allTags[i];
            if(regex.test(element.className)){
               matchingElements.push(element);
            }
        }
        //返回任何匹配的元素
        return matchingElements;
    }
    window['Blue']['getElementsByClassName'] = getElementsByClassName;
    
    /*切换DOM树中元素的可见性*/
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
    
    
    /*在一个对象之后插入一个相应的对象*/
    function insertAfter(node,referenceNode)
    {
        if(!(node = $(node))) return false; 
                //node为引用时检查是否存在 node为字符串时$函数可返回node相应的对象
        
        if(!(referenceNode = $(referenceNode))) return false;
        
        return referenceNode.parentNode.insertBefore(node,referenceNode.nextSibling);
                //referenceNode.parentNode父节点调用insertBefore插入子节点referenceNode的下一个节点    
    }
    window['Blue']['insertAfter'] = insertAfter;
    
    
    /*移除一个子节点*/
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
    
    
    /*绑定函数环境到指定的对象*/
    function bindFunction(obj,func)
    {
        return function()
        {
            func.apply(obj,arguments);
        };
    } 
    window['Blue']['bindFunction'] = bindFunction;
    
    
   /*获取窗口大小*/
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