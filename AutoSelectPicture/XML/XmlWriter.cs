using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace AutoSelectPicture
{
    class XmlWriter
    {   
    	//
    	const string  xlmFile = "setting.xml";
    	List<string>  innerTextList = new List<string>();
    	List<XmlNode> nodeList=new List<XmlNode>();
    	//
        public XmlWriter()
        {
        	//Init();
        }
		
        //初始化setting.xml文件
        public void Init()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XElement settingFile =new XElement("settings", new XElement("pictureDir", @"D:\刘亦菲"),
                                     new XElement("pictureStyle","jpg|"));
            xmlDocument.LoadXml(settingFile.ToString());
            xmlDocument.Save(xlmFile);
        }
        
        /*
         * 功能:递归查找节点名称及节点名称
         * 参数:
         * 1.nodeName    节点名称
         * 2.xmlNodeList 获得的子结点的集合
         * 返回值:
         * 返回匹配节点列表
         * 
         * XML文件举例:
         * <settings>
         *  <pictureDir>D:\照片\刘亦菲</pictureDir>
         *  <pictureStyle>jpg|</pictureStyle>
         * </settings>
         * 
         * 调用举例:
         * string result = Query("pictureDir");
         * 入参 
         *  nodeName:"pictureDir"
         * 返回值:
         *  D:\照片\刘亦菲
         */
        private List<string> QueryNodeNameList(string nodeName,XmlNodeList xmlNodeList)
        {
        	//清空列表
        	if(nodeList.Count!=0)
        	{
        		nodeList.Clear();
        	}
        	if(xmlNodeList.Count!=0)
        	{
        		foreach(XmlNode xmlNode in xmlNodeList)
        		{
        			/*
                     *如果是节点的文本内容,退出循环
                     * 比如XML:
                     *<settings>
                     *<pictureDir>D:\照片\刘亦菲</pictureDir>
                     *<pictureStyle>jpg|</pictureStyle>
                     *</settings>
                     * 
                     * 会依次遍历以下结点:
                     * 1. settings       类型:XmlElement 有两个子结点:  pictureDir
                     *                                                pictureStyle
                     * 2. pictureDir     类型:XmlElement 有一个子结点:  D:\照片\刘亦菲
                     * 3. D:\照片\刘亦菲  类型:XmlText    没有子结点
                     * 4. pictureStyle   类型:XmlElement 有一个子结点:  jpg|
                     * 5. jpg|           类型:XmlText    没有子结点
                     */  
                    //不判断XmlText类型的结点 
        			if(xmlNode.GetType().Name=="XmlText")
        			{
        				break;
        			}      			
        			//判断XmlElement结点名称
        			if (xmlNode.Name==nodeName)
        			{//查找该节点名称是否匹配
        				//找到匹配结点
        				string innerText = xmlNode.InnerText;
        				innerTextList.Add(innerText);
        				nodeList.Add(xmlNode);
        			}
        			else
        			{//查找该节点名称是不匹配,继续查找其子结点
        				//获得子结点的集合
        				XmlNodeList xmlSubNodeList = xmlNode.ChildNodes;
        				QueryNodeNameList(nodeName,xmlSubNodeList);

        			}
        		}
        	}
        	return innerTextList;
        }
        
        /*
         * 功能:递归更新节点文本
         * 参数:
         * 1.nodeName    节点名称
         * 2.innerText   更新结点的文本
         * 3.xmlNodeList 获得的子结点的集合
         * 返回值:
         * 
         */
        private void UpdateNodeNameList(string nodeName,string innerText,XmlNodeList xmlNodeList)
        {
        	//清空列表
        	if(nodeList.Count!=0)
        	{
        		nodeList.Clear();
        	}
        	if(xmlNodeList.Count!=0)
        	{
        		foreach(XmlNode xmlNode in xmlNodeList)
        		{
        			/*
                     *如果是节点的文本内容,退出循环
                     * 比如XML:
                     *<settings>
                     *<pictureDir>D:\照片\刘亦菲</pictureDir>
                     *<pictureStyle>jpg|</pictureStyle>
                     *</settings>
                     * 
                     * 会依次遍历以下结点:
                     * 1. settings       类型:XmlElement 有两个子结点:  pictureDir
                     *                                                pictureStyle
                     * 2. pictureDir     类型:XmlElement 有一个子结点:  D:\照片\刘亦菲
                     * 3. D:\照片\刘亦菲  类型:XmlText    没有子结点
                     * 4. pictureStyle   类型:XmlElement 有一个子结点:  jpg|
                     * 5. jpg|           类型:XmlText    没有子结点
                     */  
                    //不判断XmlText类型的结点 
        			if(xmlNode.GetType().Name=="XmlText")
        			{
        				break;
        			}
        			
        			//判断XmlElement结点名称
        			if (xmlNode.Name == nodeName)
        			{//查找该节点名称是否匹配
        				//保存更新前的结点
        				nodeList.Add(xmlNode);
        				//如果找到匹配结点
        				xmlNode.InnerText=innerText;

        			}
        			else
        			{//查找该节点名称是不匹配,继续查找其子结点
        				//获得子结点的集合
        				XmlNodeList xmlSubNodeList = xmlNode.ChildNodes;
        				UpdateNodeNameList(nodeName,innerText,xmlSubNodeList);
        			}
        		}
        	}
        	return ;
        }
        
        /*
         * 方法功能:查询
         * 入参:nodeName 结点名称
         * 返回值:结点innerText 列表
         * 举例:
         * <settings>
         *  <pictureDir>D:\照片\刘亦菲</pictureDir>
         *  <pictureDir>D:\照片\刘亦菲\1</pictureDir>
         *  <pictureStyle>jpg|</pictureStyle>
         * </settings>
         * 
         * 举例:
         * List<string> result = QueryNodes("pictureDir");
         * 入参 
         * nodeName: "pictureDir"
         * 返回值:
         * D:\照片\刘亦菲
         * D:\照片\刘亦菲\1
         * 
         * 说明:
         * 1. getInnerTextList() 方法取得查找到的结点内容
         * 2. getXmlNodeList()   方法取得查找到的结点
         */
        public List<string>  QueryNodes(string XmlElementName)
        {
        	XmlDocument xmlDocument = new XmlDocument();
        	//读取XML文件
            xmlDocument.Load(xlmFile);
            //读取XML文件根节点
        	XmlNodeList xmlNodeList=xmlDocument.ChildNodes;
        	return QueryNodeNameList(XmlElementName,xmlNodeList);
        }        

		/*
         * 方法功能:更新节点内容
         * 入参:nodeName   结点名称
         * 入参:innerText  设置的内容
         * 返回值:结点内容 
         * 举例:
         * XML文件
         * <settings>
         *  <pictureDir>D:\照片\刘亦菲</pictureDir>
         *  <pictureStyle>jpg|</pictureStyle>
         * </settings>
         * 
         * 举例:
         * UpdateNodes("pictureDir","D:\照片\刘亦菲\1");
         * 入参 
         * nodeName :"pictureDir"
         * innerText:"D:\照片\刘亦菲\1"
         *
         * 执行方法后XML文件:
         * <settings>
         *  <pictureDir>D:\照片\刘亦菲\1</pictureDir>
         *  <pictureStyle>jpg|</pictureStyle>
         * </settings>
         * 
         * 说明:
         * 1.如果有相同的节点名称，相同的节点名称的内容都被更新  
         * 2.使用 getXmlNodeList() 方法可获得更新前的结点
         */
		public void UpdateNodes(string XmlElementName,string innerText)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xlmFile);
            XmlNodeList xmlNodeList = xmlDocument.ChildNodes;
            UpdateNodeNameList(XmlElementName,innerText,xmlNodeList);
            xmlDocument.Save(xlmFile);
            return;
        }
		
		//返回结点内容列表
		public List<string> GetInnerTextList(){
			return innerTextList;
		}
		
		//返回结点列表
		public List<XmlNode> GetXmlNodeList(){
			return nodeList;
		}
    }
}
