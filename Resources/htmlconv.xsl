<?xml version="1.0" encoding="UTF-8"?>

<!-- для NET версии читалки. -->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:F="http://www.gribuser.ru/xml/fictionbook/2.0" xmlns:L="http://www.w3.org/1999/xlink">

  <!-- полный доктайп (с doctype-system) прописывать нельзя, сломаешь прокрутку!!! -->
  <xsl:output method="html" encoding="UTF-8" version="4.01" doctype-public="-//W3C//DTD HTML 4.01 Transitional//EN" indent="yes" />

  <!-- create <img> elements or not? -->
  <xsl:param name="imgprefix" select="''" />
  <xsl:param name="includedesc" select="1" />
  <xsl:param name="tocdepth" select="5" /> <!--  уровень вложенности заголовков, вносимых в TOC -->

  <!-- note about attributes: this template can be called
	with both qualified and unqualified attributes,
	so we have to accept both
   
<xsl:output method="html" 
encoding="utf-8"
version="4.01"
doctype-public="-//W3C//DTD HTML 4.01 Transitional//EN"
doctype-system="http://www.w3.org/TR/1999/REC-html401-19991224/loose.dtd"
indent="yes"/>    -->

  <xsl:template match="/">
    <html>
      <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <style>
          /*
          a:link, a:visited		{	color:#13E;}
          a:hover					{	color:#c42;}
          a:active				{	color:#f20;}
          */
      
          /* параметры главного окна ( поле документа)*/
          body					{width:95%;
          margin: 2%;
          font-family: "Bookman Old Style" "Comic Sans MS";
          /*line-height:150%;
          font-size:0.25in;*/
          }

          /* debuggers 
          .epigraph				{border:1px solid red;}
          .epigraphcontainer		{border:1px solid blue;}
          ul						{border:1px solid red;}
          li						{border:1px solid blue;}
          .poem					{border: 1px solid green;}
          .stanza 				{border:1px solid red;}
          .stanza p				{border:1px solid blue;}
          */
			
          /* дальше стили для текста. */
          /* фильтру "тень" зачем-то обязательно хочется, чтобы элемент имел ширину или высоту.*/
          h1,h2,h3,h4,h5,h6		{ text-align: center; padding-bottom:1em;}
      
          h1						{ font-size: 200%; color:#00f;font-weight: bold;}
          h2						{ font-size: 180%; color:#00d;font-weight: bold;}
          h3						{ font-size: 160%; color:#00b;font-weight: bold;}
          h4						{ font-size: 140%; color:#009;font-weight: bold;}
          h5						{ font-size: 120%; color:#007;font-weight: normal;}
          h5.subtitle	  { font-style:italic;}
          h6						{ font-size: 100%; color:#001;font-weight: normal;}
          p						  { margin-top: 0pt; margin-bottom: 0.1em; text-indent: 3em; text-align: justify; }
          img						{ border: none;}
			
          blockquote		{display:block;
          width:90%;word-wrap: break-word;
          color: #040;
          font-size: 90%;
          font-style:italic;
          border: 1px dotted #555;
          padding:1em 5% 0em 5%;
          margin-bottom:1em;}
									
          hr						{ margin: 3em;}
          ul						{ display: block;}
          li						{ display: block; margin-left:1em;}

          .epigraph				{ display:block; width:45%; margin: 0pt; font-size: 70%; font-style:italic;}
          .epigraph p				{ text-indent: 2em;}
          .epigraphcontainer		{ width:100%;text-align:right;}

          /* .espace					{ clear: right; margin: 0pt; padding: 0pt; } */
          .author					{ margin-left: 1em; margin-bottom: 1em; color: #626;text-align:right; }
          .poem 					{ margin: 1em 5em 1em ; padding: 1em; }
          .stanza 		 		{ margin-top: 1em; }
          .stanza p				{ text-align: left; text-indent: 0pt; }
          .annotation 			{ border: groove; font-size: 60%; line-height:100%; margin: 0.5em; padding: 1em; }
          .mt_subtitle			{ text-align:center; margin-left:10%; margin-right:10%; font-style:italic;}
          .center					{ text-align: center; }

          /* таблица в документе. */
          /* юзать для таблицы text-align нельзя! это помешает корректной работе атрибута align, транслируемого из фбука. */
          .fbtable				{ width: 80%; margin:2em 0;}
          .fbtable tr				{}
          .fbtable th				{ border:solid 1px black; padding:0.5em;}
          .fbtable td				{ border:solid 1px black; padding:0.5em;}


          /* сноски в документе */
          a.footnote				{text-decoration: none;}
          a.footnote:link,
          a.footnote:visited		{color:#f44;}
          a.footnote:active		{color:#f00;}
        </style>

      </head>
      <body>
        <xsl:if test="/F:FictionBook/F:description/F:title-info/F:coverpage">
          <div style="float:left; margin: 2em; border: outset;">
            <xsl:apply-templates select="/F:FictionBook/F:description/F:title-info/F:coverpage/F:image" />
          </div>
        </xsl:if>
					
        <!-- image from the first body -->
        <xsl:apply-templates select="/F:FictionBook/F:body[1]/F:image[1]" mode="first" />
    
        <!-- title from the first body -->
        <xsl:apply-templates select="/F:FictionBook/F:body[1]/F:title[1]" mode="first" />

        <!-- annotation -->
        <xsl:apply-templates select="/F:FictionBook/F:description/F:title-info/F:annotation" />				
	
        <!-- main text -->
        <xsl:apply-templates select="/F:FictionBook/F:body" />
		
        <!-- table of contents -->
        <xsl:if test="//F:section/F:title">
          <div id="dtoc" style="display:nonne;">
            <ul>
              <xsl:apply-templates mode="toc" select='/F:FictionBook/F:body[not(@name="notes")]/F:section' />
            </ul>
          </div>
        </xsl:if>

        <xsl:if test="/F:FictionBook/F:binary">
          <hr />
          <small>
            Этот файл содержит вложения, числом
            <xsl:value-of select="count(//F:FictionBook/F:binary)" />
            .
            <a href="#" onclick="piclist.style.display='block'">Показать...</a>
            <br />
            <table id="piclist" style="display:block;">
              <xsl:for-each select="/F:FictionBook/F:binary">
                <tr>
                  <td style="padding:2px;">
                    <img style="height:48px;">
                      <xsl:attribute name="name">
                        #
                        <xsl:value-of select="@id" />
                      </xsl:attribute>
                    </img>
                  </td>
                  <td>
                    <a>
                      <xsl:attribute name="href">
                        #
                        <xsl:value-of select="@id" />
                      </xsl:attribute>
                      <xsl:value-of select="@id" />
                    </a>
                  </td>
                </tr>
              </xsl:for-each>
            </table>
          </small>
        </xsl:if>
		
        <!-- generate description -->
        <div id="docprop" style="display:block;">
      
          <!-- description properties -->
          <a name="_fbh_description" />
          <table class="props">
            <tr><!--td class="ticap">
					CoverPage
				</td--><td colspan="2">
                                                                    <xsl:if test="/F:FictionBook/F:description/F:title-info/F:coverpage">
                                                                      <xsl:apply-templates select="/F:FictionBook/F:description/F:title-info/F:coverpage/F:image" />
                                                                    </xsl:if>
                                                                  </td>
            </tr>
            <xsl:apply-templates select="/F:FictionBook/F:description/F:title-info" />
            <xsl:apply-templates select="/F:FictionBook/F:description/F:document-info" />
            <xsl:apply-templates select="/F:FictionBook/F:description/F:publish-info" />
            <xsl:if test="/F:FictionBook/F:description/F:custom-info">
              <tr>
                <td class="propsec" colspan="2">Custom Info</td>
                <xsl:apply-templates select="/F:FictionBook/F:description/F:custom-info" />
              </tr>
            </xsl:if>
          </table>
        </div>
    
        <!-- ныкаем сюда картинки :) >
		<xsl:apply-templates select="/F:FictionBook/F:binary"/-->
		
        <!--<конец главной таблицы >-->
      </body>
    </html>
  </xsl:template>

  <xsl:template match='/F:FictionBook/F:description/F:title-info/F:coverpage/F:image'>
    <img id="bsCoverPageImage" style="display:noqne;">
      <xsl:attribute name="name">
        <xsl:value-of select="concat($imgprefix,@L:href)" />
      </xsl:attribute>
      <xsl:attribute name="src">
        <xsl:value-of select="concat($imgprefix,substring(@L:href,2))" />
      </xsl:attribute>
    </img>
  </xsl:template>	

  <!-- text body. блокируем тот боди, который содержит сноски.  -->
  <xsl:template match='F:body[not(@name="notes")]'>
    <br clear="all" />
    <hr />
    <xsl:apply-templates />
  </xsl:template>
	
  <!-- сноски. их мы не показываем, но шаблон нужен, чтоб не было нераспознанных элементов. -->
  <xsl:template match='F:body[(@name="notes")]'>
    <hr />
    <small>
      Этот файл содержит примечания, доступные по ссылкам в тексте.
    </small>
  </xsl:template> 
	
  <!-- text sections -->
  <xsl:template match="F:section">
    <!-- add an anchor for intra-document links -->
    <xsl:call-template name="id" />
    <!-- add a anchor for toc -->
    <xsl:if test="F:title">
      <a>
        <xsl:attribute name="name">
          <xsl:text>_toc_</xsl:text>
          <xsl:value-of select="generate-id()" />
        </xsl:attribute>
      </a>
    </xsl:if>
    <xsl:apply-templates />
  </xsl:template>
	
  <!-- special case to insert table of contents after the first header -->
  <xsl:template match="/F:FictionBook/F:body[1]/F:title[1]">
    <!-- swallow this header in normal mode -->
  </xsl:template>

  <xsl:template match="/F:FictionBook/F:body[1]/F:title[1]" mode="first">
    <!--xsl:call-template name="sb-title"/-->
    <xsl:for-each select="F:p | F:empty-line">
      <xsl:element name="h1">
        <xsl:apply-templates />
        <br />
        <br />
      </xsl:element>
    </xsl:for-each>
  </xsl:template>

  <!-- специальная обработка секций примечаний >
	<xsl:template match="F:section">
		<xsl:apply-templates/>
	</xsl:template-->
  <!-- специальная обработка заголовков примечаний -->
  <xsl:template match="/F:FictionBook/F:body[@name='notes']//F:title">
    <xsl:element name="h3">
      <xsl:for-each select="F:p | F:empty-line">
        <xsl:apply-templates />
      </xsl:for-each>
    </xsl:element>
  </xsl:template>

  <xsl:template match="/F:FictionBook/F:body[1]/F:image[1]">
    <!-- swallow this header in normal mode -->
  </xsl:template>

  <xsl:template match="/F:FictionBook/F:body[1]/F:image[1]" mode="first">
    <xsl:call-template name="sb-image" />
  </xsl:template>

  <xsl:template match="F:title">
    <xsl:call-template name="sb-title" />
  </xsl:template>

  <!-- section and body titles -->
  <xsl:template name="sb-title">
    <!-- figure an appropriate heading -->
    <xsl:variable name="level" select="2+count(ancestor::F:section)+count(ancestor::F:description)" />
    <xsl:choose>
      <!-- always use h4 when nesting level is >4 h5-->
      <xsl:when test="$level>4">
        <xsl:for-each select="F:p | F:empty-line">
          <xsl:if test="position()=1">
            <br />
            <h4>
              <xsl:apply-templates />
            </h4>
            <br />
          </xsl:if>
          <xsl:if test="position()>1">
            <div class="mt_subtitle">
              <xsl:apply-templates />
            </div>
            <br />
          </xsl:if>
        </xsl:for-each>
      </xsl:when>
      <xsl:otherwise>
        <xsl:for-each select="F:p | F:empty-line">
          <xsl:if test="position()=1">
            <xsl:element name="h{$level}">
              <br />
              <xsl:apply-templates />
            </xsl:element>
          </xsl:if>
          <xsl:if test="position()>1">
            <div class="mt_subtitle">
              <xsl:apply-templates />
            </div>
            <br />
          </xsl:if>
        </xsl:for-each>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <!-- we have to jump through the hoops because Hx elements can't have block level content in them -->
  <xsl:template name="hx-title">
    <xsl:for-each select="F:p | F:empty-line">
      <xsl:if test="position()>1">
        <br />
      </xsl:if>
      <xsl:apply-templates />
    </xsl:for-each>
  </xsl:template>

  <!-- Аннотация документа. -->
  <xsl:template match="F:annotation">
    <div class="annotation">
      <xsl:call-template name="id" />
      <a name="#_fbh_annotation" />
      <xsl:apply-templates />
    </div>
  </xsl:template>

  <!-- Обычный параграф -->
  <xsl:template match="F:p">
    <p>
      <xsl:call-template name="id" />
      <xsl:apply-templates />
    </p>
  </xsl:template>

  <!-- empty-lines -->
  <xsl:template match="F:empty-line">
    <!--
		<p style="font-family: Arial; text-style: normal;" title="В целях отладки, тэг empty-line трансформируется в видимый знак 'конец абзаца'">¶</p>
		-->
    <p>&#160;</p>
  </xsl:template>

  <!-- text decoration inside paragraphs: strong, emphasis -->
  <xsl:template match="F:sup">
    <sup>
      <xsl:apply-templates />
    </sup>
  </xsl:template>
  <xsl:template match="F:sub">
    <sub>
      <xsl:apply-templates />
    </sub>
  </xsl:template>
  <xsl:template match="F:code">
    <code>
      <xsl:apply-templates />
    </code>
  </xsl:template>
  <xsl:template match="F:strong">
    <strong>
      <xsl:apply-templates />
    </strong>
  </xsl:template>
  <xsl:template match="F:emphasis">
    <em>
      <xsl:apply-templates />
    </em>
  </xsl:template>
  <xsl:template match="F:strikethrough">
    <s>
      <xsl:apply-templates />
    </s>
  </xsl:template>

  <!-- hyperlinks in text. -->
  <xsl:template match='F:a[not(@type="note")]'>
    <xsl:choose>
      <xsl:when test="starts-with(@L:href,'#')">
        <xsl:variable name="hrefid" select="substring(@L:href,2)" />
        <xsl:choose> <!-- Тут мы разруливаем невалидные нотесы. -->
          <xsl:when test="/F:FictionBook/F:body[@name='notes']/F:section[@id=$hrefid]">
            <span style="color:red; background:yellow;" title="ЭТА ССЫЛКА ОПИСАНА НЕВЕРНО И МОЖЕТ НЕ РАБОТАТЬ В ДРУГИХ ПРОГРАММАХ.">
              <xsl:text>
                [ НЕВАЛИДНЫЙ ФАЙЛ! ]
              </xsl:text>
            </span>
            <xsl:call-template name="footnote" />
          </xsl:when>
          <xsl:otherwise>
            <xsl:if test="/F:FictionBook/F:body[not(@name='notes')]//*[@id=$hrefid]">
              <a> <!-- Тут — внутренние ссылки, в пределах документа. -->
                <xsl:attribute name="href">
                  <xsl:value-of select="@L:href" />
                </xsl:attribute>
                <xsl:attribute name="title">
                  <xsl:text>
                    Ссылка на маркер в этом документе.
                  </xsl:text>
                </xsl:attribute>
                <font face="wingdings">
                  <xsl:text>F</xsl:text>
                </font>
                <xsl:apply-templates />
              </a>
            </xsl:if>
            <xsl:if test="not(/F:FictionBook/F:body[not(@name='notes')]//*[@id=$hrefid])">
              <span style="color:red; background:yellow;" title="ССЫЛКА НА ВНУТРЕННИЙ МАРКЕР, ОТСУТСТВУЮЩИЙ В ДОПУСТИМОМ ДИАПАЗОНЕ.">
                <xsl:text>
                  [ НЕВАЛИДНЫЙ ФАЙЛ! ]
                </xsl:text>
              </span>
            </xsl:if>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:when>
      <xsl:otherwise>
        <a><!-- Тут — настоящие ссылки, внешние. -->
          <xsl:attribute name="href">
            <xsl:value-of select="@L:href" />
          </xsl:attribute>
          <xsl:attribute name="title">
            <xsl:value-of select="@L:href" />
          </xsl:attribute>
          <font face="webdings">
            <xsl:text>"</xsl:text>
          </font>
          <xsl:apply-templates />
        </a>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
	
  <!-- это нормальные нотесы. -->
  <xsl:template match='F:a[@type="note"]'>
    <xsl:call-template name="footnote" />
  </xsl:template>
	
  <!-- footnote. by Black Snake-->
  <xsl:template name="footnote">
    <xsl:variable name="noteid" select="substring(@L:href,2)" />
    <xsl:choose>
      <xsl:when test="/F:FictionBook/F:body[@name='notes']//F:section[@id=$noteid]">
        <a class="footnote">
          <!--a class="footnote" onblur="HideFootNote()">
					<xsl:attribute name="onfocus">ShowFootNote(<xsl:value-of select="$noteid" />.innerHTML)</xsl:attribute-->
          <xsl:attribute name="href">
            note:
            <xsl:value-of select="$noteid" />
          </xsl:attribute>
          <!--	в титл идёт только первый абзац сноски 
						и вообще титл больше не нужен.
				<xsl:attribute name="title">
				<xsl:value-of select="/F:FictionBook/F:body[@name='notes']/F:section[@id=$noteid]/F:p" />
				</xsl:attribute>-->
				
          <!--
				TODO: обдумать вариант с использованием <xsl:text disable-output-escaping = "yes"></xsl:text>
				-->
          <sup>
            <xsl:apply-templates />
          </sup>
        </a>
        <comment>
          <xsl:attribute name="id">
            <xsl:value-of select="$noteid" />
          </xsl:attribute>
          <xsl:apply-templates select="/F:FictionBook/F:body[@name='notes']//F:section[@id=$noteid]" />
        </comment>
				
        <!--comment>
					<xsl:attribute name="id"><xsl:value-of select="$noteid" /></xsl:attribute>
					<dl><dt><xsl:value-of select="/F:FictionBook/F:body[@name='notes']//F:section[@id=$noteid]/F:title" /></dt>
					<xsl:for-each select="/F:FictionBook/F:body[@name='notes']//F:section[@id=$noteid]/F:p">
						<dd><xsl:value-of select="." /></dd>
					</xsl:for-each></dl>
				</comment-->
				
        <!--comment style="display: none !important;">
					<xsl:attribute name="id"><xsl:value-of select="$noteid" /></xsl:attribute>
					<dl><dt><xsl:value-of select="/*/F:section[@id=$noteid]/F:title" /></dt>
					<xsl:for-each select="/*/F:section[@id=$noteid]/F:p">
						<dd><xsl:value-of select="." /></dd>
					</xsl:for-each></dl>
				</comment-->
      </xsl:when>
      <xsl:otherwise>
        <span style="color:red; background:yellow;" title="ОТСУТСТВУЕТ ПРИМЕЧАНИЕ, НА КОТОРОЕ ССЫЛАЕТСЯ ЭТА ССЫЛКА. ">
          <xsl:text>
            [ НЕВАЛИДНЫЙ ФАЙЛ! ]
          </xsl:text>
        </span>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>		

  <!-- images -->
  <xsl:template match="F:image">
    <xsl:call-template name="sb-image" />
  </xsl:template>
  <xsl:template name="sb-image">
    <xsl:call-template name="id" />
    <a>
      <xsl:attribute name="name">
        <xsl:value-of select="concat($imgprefix,@L:href)" />
      </xsl:attribute>
    </a>
    <div class="center">
      <img border="1">
        <xsl:attribute name="name">
          <xsl:value-of select="concat($imgprefix,@L:href)" />
        </xsl:attribute>
        <xsl:choose>
          <xsl:when test="starts-with(@L:href,'#')">
            <!-- это интегрированная картинка -->
            <xsl:attribute name="src">
              <xsl:value-of select="concat($imgprefix,substring(@L:href,2))" />
            </xsl:attribute>
          </xsl:when>
          <xsl:otherwise>
            <!-- это внешняя картинка, с прямым адресом. -->
            <xsl:attribute name="src">
              <xsl:value-of select="concat($imgprefix,@L:href)" />
            </xsl:attribute>
          </xsl:otherwise>
        </xsl:choose>
      </img>
    </div>
  </xsl:template>

  <xsl:template match="F:binary">
    <!-- Нам нафиг не нужен бинари, но шаблон должен быть, иначе возможна ошибка неизвестного тэга -->
    <!--div class="binary" style="display:none;">
			<xsl:attribute name="id">
				<xsl:value-of select="@id | @F:id"/>
			</xsl:attribute>
			<xsl:apply-templates/>
		</div-->
  </xsl:template>	
	
	
  <!-- hyperlink targets -->
  <xsl:template name="id">
    <xsl:if test="@id | @F:id">
      <a>
        <xsl:attribute name="name">
          <xsl:value-of select="@id | @F:id" />
        </xsl:attribute>
      </a>
    </xsl:if>
  </xsl:template>

  <!-- style elements are converted into span -->
  <xsl:template match="F:style">
    <span>
      <xsl:attribute name="class">
        <xsl:text>xc_</xsl:text>
        <xsl:value-of select="@name | @F:name" />
      </xsl:attribute>
      <xsl:apply-templates />
    </span>
  </xsl:template>

  <!-- subtitles 
	<xsl:template match="F:subtitle">
		<h5><xsl:apply-templates/></h5>
	</xsl:template>-->
	
  <xsl:template match="F:subtitle">
    <xsl:call-template name="id" />
    <h5>
      <xsl:if test="preceding-sibling::F:title">
        <xsl:attribute name="class">subtitle</xsl:attribute>
      </xsl:if>
      <xsl:apply-templates />
    </h5>
  </xsl:template>

  <!-- epigraphs -->
  <xsl:template match="F:epigraph">
    <xsl:call-template name="id" />
    <!-- move epigraph to the far right>
		<table border="0" width="100%">
		<tr><td>&#160;</td>
		<td align="right"></td></tr></table -->

    <div class="epigraphcontainer">
      <div class="epigraph">
        <xsl:apply-templates />
      </div>
    </div>
  </xsl:template>

  <!-- citations <fieldset unselectable="on" class="blockquote"><legend unselectable="on"><small>Цитата</small></legend></fieldset> -->
  <xsl:template match="F:cite">
    <blockquote>

      <xsl:call-template name="id" />
      <xsl:apply-templates />
    </blockquote>
  </xsl:template>

  <!-- poems -->
  <xsl:template match="F:poem">
    <xsl:call-template name="id" />
    <div class="poem">
      <xsl:apply-templates />
    </div>
  </xsl:template>

  <xsl:template match="F:stanza">
    <div class="stanza">
      <xsl:apply-templates />
    </div>
  </xsl:template>

  <xsl:template match="F:poem/F:title">
    <h4 style="text-align:left">
      <xsl:apply-templates />
    </h4>
  </xsl:template>
  <xsl:template match="F:stanza/F:title">
    <h5 style="text-align:left">
      <xsl:apply-templates />
    </h5>
  </xsl:template>
  <xsl:template match="F:stanza/F:subtitle">
    <h5 style="text-align:left; font-style:italic;">
      <xsl:apply-templates />
    </h5>
  </xsl:template>

  <xsl:template match="F:poem/F:epigraph">
    <xsl:call-template name="id" />
    <div class="epigraph" style="float:left;">
      <xsl:apply-templates />
    </div>
    <br clear="all" />
  </xsl:template>

  <xsl:template match="F:v">
    <p>
      <xsl:apply-templates />
    </p>
  </xsl:template>

  <!-- epigraph/citation/poem author -->
  <xsl:template match="F:text-author">
    <p class="author">
      <xsl:apply-templates />
    </p>
  </xsl:template>

  <!-- table (by Black Snake) -->
  <xsl:template match="F:table">
    <xsl:call-template name="id" />
    <table border="1" class="fbtable">
      <xsl:if test="@style | @F:style">
        <xsl:attribute name="style">
          <xsl:value-of select="@style | @F:style" />
        </xsl:attribute>
      </xsl:if>
      <xsl:apply-templates />
    </table>
  </xsl:template>

  <xsl:template match="F:table/F:caption"><!-- НЕВАЛИДНЫЙ ТЭГ!!! -->
    <caption>
      <span style="color:red; background:yellow;" title="ТЭГА 'CAPTION' НЕТ В СПЕЦИФИКАЦИИ FB2.1">
        <xsl:text>
          [ НЕВАЛИДНЫЙ ФАЙЛ! ]
        </xsl:text>
        <xsl:apply-templates />
        <xsl:text>
          [ НЕВАЛИДНЫЙ ФАЙЛ! ]
        </xsl:text>
      </span>
    </caption>
  </xsl:template>

  <xsl:template match="F:table/F:col"><!-- НЕВАЛИДНЫЙ ТЭГ!!! -->
    <!-- мессадж будет "выплюнут" из таблицы, но это неважно.-->
    <span style="color:red; background:yellow;" title="ТЭГА 'COL' НЕТ В СПЕЦИФИКАЦИИ FB2.1">
      <xsl:text>
        [ НЕВАЛИДНЫЙ ФАЙЛ! ]
      </xsl:text>
    </span>
    <col>
      <xsl:if test="@width | @F:width">
        <xsl:attribute name="width">
          <xsl:value-of select="@width | @F:width" />
        </xsl:attribute>
      </xsl:if>
    </col>
  </xsl:template>

  <xsl:template match="F:table/F:tr">
    <tr>
      <xsl:attribute name="align">left</xsl:attribute><!-- аттрибут будет переназначен, если есть чем. -->
      <xsl:if test="@align | @F:align">
        <xsl:attribute name="align">
          <xsl:value-of select="@align | @F:align" />
        </xsl:attribute>
      </xsl:if>
      <xsl:apply-templates />
    </tr>
  </xsl:template>
  <xsl:template match="F:table/F:tr/F:th">
    <th>
      <xsl:call-template name="id" />
      <xsl:if test="@style | @F:style">
        <xsl:attribute name="style">
          <xsl:value-of select="@style | @F:style" />
        </xsl:attribute>
      </xsl:if>
      <xsl:if test="@colspan | @F:colspan">
        <xsl:attribute name="colspan">
          <xsl:value-of select="@colspan | @F:colspan" />
        </xsl:attribute>
      </xsl:if>
      <xsl:if test="@rowspan | @F:rowspan">
        <xsl:attribute name="rowspan">
          <xsl:value-of select="@rowspan | @F:rowspan" />
        </xsl:attribute>
      </xsl:if>
      <xsl:if test="@align | @F:align">
        <xsl:attribute name="align">
          <xsl:value-of select="@align | @F:align" />
        </xsl:attribute>
      </xsl:if>
      <xsl:apply-templates />
    </th>
  </xsl:template>
  <xsl:template match="F:table/F:tr/F:td">
    <td>
      <xsl:call-template name="id" />
      <xsl:if test="@style | @F:style">
        <xsl:attribute name="style">
          <xsl:value-of select="@style | @F:style" />
        </xsl:attribute>
      </xsl:if>
      <xsl:if test="@colspan | @F:colspan">
        <xsl:attribute name="colspan">
          <xsl:value-of select="@colspan | @F:colspan" />
        </xsl:attribute>
      </xsl:if>
      <xsl:if test="@rowspan | @F:rowspan">
        <xsl:attribute name="rowspan">
          <xsl:value-of select="@rowspan | @F:rowspan" />
        </xsl:attribute>
      </xsl:if>
      <xsl:if test="@align | @F:align">
        <xsl:attribute name="align">
          <xsl:value-of select="@align | @F:align" />
        </xsl:attribute>
      </xsl:if>
      <xsl:apply-templates />
    </td>
  </xsl:template>

  <!-- если дошло до звезды, значит ни одно другое правило не подошло. -->
  <xsl:template match="F:*">
    <div style="color:red; background:yellow;" title="ЭТО СОДЕРЖИМОЕ ВЛОЖЕНО В ТЭГ, ОТСУТСТВУЮЩИЙ В СХЕМЕ СТАНДАРТА FB2.1, ИЛИ ТЭГ НАХОДИТСЯ ТАМ, ГДЕ НЕ МОЖЕТ НАХОДИТЬСЯ.">
      <xsl:text>[ НЕВАЛИДНЫЙ ФАЙЛ! ]</xsl:text>
      <br />
      <xsl:apply-templates />
      <br />
      <xsl:text>[ НЕВАЛИДНЫЙ ФАЙЛ! ]</xsl:text>
    </div>
    <br />
  </xsl:template>
	
  <!-- properties -->
  <xsl:template match="F:title-info">
    <tr>
      <td class="propsec" colspan="2">Title Info</td>
    </tr>
    <tr>
      <td class="ticap">
        Genre
        <xsl:if test="count(F:genre) &gt; 1">s</xsl:if>
      </td>
      <td>
        <xsl:for-each select="F:genre">
          <xsl:text></xsl:text>
          <xsl:value-of select="." />
          <xsl:if test="@match &lt; 100 or @F:match &lt; 100">
            <xsl:text>[</xsl:text>
            <xsl:value-of select="@match | @F:match" />
            <xsl:text>%]</xsl:text>
          </xsl:if>
        </xsl:for-each>
      </td>
    </tr>
    <tr>
      <td class="ticap">
        Author
        <xsl:if test="count(F:author) &gt; 1">s</xsl:if>
      </td>
      <td>
        <xsl:for-each select="F:author">
          <xsl:if test="position() &gt; 1">,</xsl:if>
          <xsl:call-template name="author-prop" />
        </xsl:for-each>
      </td>
    </tr>
    <tr>
      <td class="ticap">Title</td>
      <td>
        <xsl:value-of select="F:book-title" />
      </td>
    </tr>
    <xsl:if test="F:keywords">
      <tr>
        <td class="ticap">Keywords</td>
        <td>
          <xsl:value-of select="F:keywords" />
        </td>
      </tr>
    </xsl:if>
    <xsl:apply-templates select="F:date" />
    <xsl:if test="F:lang">
      <tr>
        <td class="ticap">Language</td>
        <td>
          <xsl:value-of select="F:lang" />
        </td>
      </tr>
    </xsl:if>
    <xsl:if test="F:src-lang">
      <tr>
        <td class="ticap">Source Language</td>
        <td>
          <xsl:value-of select="F:src-lang" />
        </td>
      </tr>
    </xsl:if>
    <xsl:if test="F:translator">
      <tr>
        <td class="ticap">
          Translator
          <xsl:if test="count(F:translator) &gt; 1">s</xsl:if>
        </td>
        <td>
          <xsl:for-each select="F:translator">
            <xsl:if test="position() &gt; 1">,</xsl:if>
            <xsl:call-template name="author-prop" />
          </xsl:for-each>
        </td>
      </tr>
    </xsl:if>
  </xsl:template>

  <xsl:template match="F:document-info">
    <tr>
      <td class="propsec" colspan="2">Document Info</td>
    </tr>
    <tr>
      <td class="ticap">
        Author
        <xsl:if test="count(F:translator) &gt; 1">s</xsl:if>
      </td>
      <td>
        <xsl:for-each select="F:author">
          <xsl:if test="position() &gt; 1">,</xsl:if>
          <xsl:call-template name="author-prop" />
        </xsl:for-each>
      </td>
    </tr>
    <xsl:if test="F:program-used">
      <tr>
        <td class="ticap">Program used</td>
        <td>
          <xsl:value-of select="F:program-used" />
        </td>
      </tr>
    </xsl:if>
    <xsl:apply-templates select="F:date" />
    <xsl:if test="F:src-url">
      <tr>
        <td class="ticap">Source URL</td>
        <td>
          <a>
            <xsl:attribute name="href">
              <xsl:value-of select="F:src-url" />
            </xsl:attribute>
            <xsl:value-of select="F:src-url" />
          </a>
        </td>
      </tr>
    </xsl:if>
    <xsl:if test="F:src-ocr">
      <tr>
        <td class="ticap">Source OCR</td>
        <td>
          <xsl:value-of select="F:src-ocr" />
        </td>
      </tr>
    </xsl:if>
    <tr>
      <td class="ticap">ID</td>
      <td>
        <xsl:value-of select="F:id" />
      </td>
    </tr>
    <tr>
      <td class="ticap">Version</td>
      <td>
        <xsl:value-of select="F:version" />
      </td>
    </tr>
    <xsl:if test="F:history">
      <tr>
        <td class="ticap">History</td>
        <td>
          <xsl:apply-templates select="F:history/*" />
        </td>
      </tr>
    </xsl:if>
  </xsl:template>

  <xsl:template match="F:publish-info">
    <tr>
      <td class="propsec" colspan="2">Publisher Info</td>
    </tr>
    <xsl:if test="F:book-name">
      <tr>
        <td class="ticap">Book name</td>
        <td>
          <xsl:value-of select="F:book-name" />
        </td>
      </tr>
    </xsl:if>
    <xsl:if test="F:publisher">
      <tr>
        <td class="ticap">Publisher</td>
        <td>
          <xsl:value-of select="F:publisher" />
        </td>
      </tr>
    </xsl:if>
    <xsl:if test="F:city">
      <tr>
        <td class="ticap">City</td>
        <td>
          <xsl:value-of select="F:city" />
        </td>
      </tr>
    </xsl:if>
    <xsl:if test="F:year">
      <tr>
        <td class="ticap">Year</td>
        <td>
          <xsl:value-of select="F:year" />
        </td>
      </tr>
    </xsl:if>
    <xsl:if test="F:isbn">
      <tr>
        <td class="ticap">ISBN</td>
        <td>
          <xsl:value-of select="F:isbn" />
        </td>
      </tr>
    </xsl:if>
  </xsl:template>

  <xsl:template match="F:custom-info">
    <tr>
      <td class="ticap">
        <xsl:value-of select="@info-type | @F:info-type" />
      </td>
      <td>
        <xsl:value-of select="." />
      </td>
    </tr>
  </xsl:template>

  <xsl:template match="F:date">
    <tr>
      <td class="ticap">Date</td>
      <td>
        <xsl:value-of select="." />
        <xsl:if test="string(@value | @F:value) != concat(string(),'-01-01') and string() != string(@value | @F:value)">
          <xsl:text>(</xsl:text>
          <xsl:value-of select="@value | @F:value" />
          <xsl:text>)</xsl:text>
        </xsl:if>
      </td>
    </tr>
  </xsl:template>

  <xsl:template name="author-prop">
    <xsl:value-of select="F:first-name" />
    <xsl:text></xsl:text>
    <xsl:value-of select="F:middle-name" />
    <xsl:text></xsl:text>
    <xsl:value-of select="F:last-name" />
    <xsl:if test="F:nickname">
      <xsl:text>[</xsl:text>
      <xsl:value-of select="F:nickname" />
      ]
    </xsl:if>
    <xsl:if test="F:email">
      <xsl:text>&lt;</xsl:text>
      <xsl:value-of select="F:email" />
      &gt;
    </xsl:if>
  </xsl:template>

  <!-- table of contents generator -->
  <xsl:template match="F:section" mode="toc">
    <!-- only include sections that have a title -->
    <xsl:if test="F:title | .//F:section/F:title">
      <li>
        <xsl:if test="F:title">
          <a class="toclink">
            <xsl:attribute name="href">
              <xsl:text>#_toc_</xsl:text>
              <xsl:value-of select="generate-id()" />
            </xsl:attribute>
            <!-- insert text content -->
            <xsl:for-each select="F:title/F:p">
              <xsl:if test="position()>1">
                <xsl:text></xsl:text>
              </xsl:if>
              <xsl:value-of select="." />
            </xsl:for-each>
            <xsl:if test="./following::F:subtitle">
              <xsl:text></xsl:text>
              <i>
                <xsl:value-of select="./F:subtitle" />
              </i>
            </xsl:if>
          </a>
        </xsl:if>
        <xsl:if test=".//F:section/F:title and count(ancestor::F:section) &lt; $tocdepth">
          <ul>
            <xsl:apply-templates select="F:section" mode="toc" />
          </ul>
        </xsl:if>
      </li>
    </xsl:if>
  </xsl:template>

</xsl:stylesheet>


<!--

/* окно сообщений */
	.pwindow				{	border:1px solid red; display:noene;position:absolute;line-height:150%;  font-size:14pt; font-family: Monospace;
								background: #eee; 
								left:20%; top:20%; right:20%; bottom:20%;
								width:60%;height:60%;
								border:outset;overflow:auto;}
	.pwindow table			{	table-layout:auto; width:100%; height:100%; 
								}
	.pwindow table tr			{	width:100%;}
	.pwindow table td			{	padding:0; margin:0;}
	.pwindow .pwclose		{	width:1%; border:1px solid blue; text-align:center; vertical-align: middle;}
	.pwindow .pwclose a		{	gpadding:1em; border:3px none red; color:red; background:white;}
	.pwindow .wheader		{	height:2em;width:99%;
								overfklow:hidden; text-align: center;
								padding:1ex; margin:0; font-weight: bold; font-size: 140%; 
								vertical-align: middle;
								}
	.pwindow .wbody			{	overflow-x:hidden; overflow-y:scroll; border-top:groove; width:100%; height:100%; bottom:0; position:relative;
								padding: 2em; text-align: left;
								}
								

	.lastfiles				{ width:100%; padding:1em;
							}
	.lastfiles td			{ padding:2ex;border-top:none;  border-bottom:solid 1px blue;border-left:none;
							}
	.lf_filename			{ border-right:dashed 1px blue;
							}
	.lf_filepos				{ border-right:none
							}
	.lastfiles a				{ text-decoration:none;
							}
	/* props - таблица свойств документа, propsec - заголовок подсекции таблицы, ticap - ячейка "имя свойства" */
	table.props 					{ table-layout:auto;margin-top: 2em; border: none; border-collapse: collapse; border-spacing:100; }
	table.props td 				{ border: solid blue 0px; vertical-align: top; padding-left: 0.3em; height: 2em; word-break:break-all;}
	table.props td.propsec 		{ text-align: center; font-size:120%; font-weight: bolder; height: 2em; vertical-align:text-bottom !important; border: none !important }
	table.props td.ticap			{ font-weight:bold; color:blue; width:10ex; word-break:keep-all !important;width:10em; }

							
	kbd						{color: #484; font-style:italic;}


-->