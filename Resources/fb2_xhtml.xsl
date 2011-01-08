<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:fb="http://www.gribuser.ru/xml/fictionbook/2.0" exclude-result-prefixes="fb xlink">
  <xsl:import href="fb2_html.xsl" />
  <xsl:output method="xml" encoding="UTF-8" indent="yes" doctype-public="-//W3C//DTD XHTML 1.0 Strict//EN" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd" />

  <xsl:param name="book_id" />
  <xsl:param name="images_url" />

  <!-- image -->
  <xsl:template match="fb:image">
    <div align="center">
      <img border="1">
        <xsl:choose>
          <xsl:when test="starts-with(@xlink:href,'#')">
            <xsl:attribute name="src">
              <xsl:value-of select="concat($images_url, substring-after(@xlink:href,'#'))" />
            </xsl:attribute>
          </xsl:when>
          <xsl:otherwise>
            <xsl:attribute name="src">
              <xsl:value-of select="@xlink:href" />
            </xsl:attribute>
          </xsl:otherwise>
        </xsl:choose>
      </img>
    </div>
  </xsl:template>

  <xsl:template match="/*">
    <html>
      <head>
        <xsl:if test="fb:description/fb:title-info/fb:lang = 'ru'">
          <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        </xsl:if>
        <title>
          <xsl:value-of select="fb:description/fb:title-info/fb:book-title" />
        </title>
        <style type="text/css" media="screen">
          A { color : #0002CC }
          A:HOVER { color : #BF0000 }

          BODY { background-color : #FEFEFE; color : #000000; font-family : Verdana, Geneva, Arial, Helvetica, sans-serif; text-align : justify }
          H1 { font-size : 160%; font-style : normal; font-weight : bold; text-align : left; margin-left : 0px;  page-break-before : always; }
          H2 { font-size : 130%; font-style : normal; font-weight : bold; text-align : left; page-break-before : always; }
          H3 { font-size : 110%; font-style : normal; font-weight : bold; text-align : left; }
          H4 { font-size : 100%; font-style : normal; font-weight : bold; text-align : left; }
          H5 { font-size : 100%; font-style : italic; font-weight : bold; text-align : left; }
          H6 {  font-size : 100%; font-style : italic; font-weight : normal; text-align : left;}

          SMALL{ font-size : 80% }
          BLOCKQUOTE { margin-left :4em; margin-top:1em; margin-right:0.2em;}
          HR { color : Black }
          UL {margin-left: 0}
          .epigraph{width:50%; margin-left : 35%;}
        </style>
      </head>
      <body>
        <xsl:for-each select="fb:description/fb:title-info/fb:annotation">
          <div>
            <xsl:call-template name="annotation" />
          </div>
          <hr />
        </xsl:for-each>

        <!-- BUILD TOC -->
        <ul>
          <xsl:apply-templates select="fb:body" mode="toc" />
        </ul>
        <hr />

        <!-- BUILD BOOK -->
        <xsl:for-each select="fb:body">
          <xsl:if test="position()!=1">
            <hr />
          </xsl:if>
          <xsl:if test="@name">
            <h4 align="center">
              <xsl:value-of select="@name" />
            </h4>
          </xsl:if>
          <xsl:apply-templates />
        </xsl:for-each>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>