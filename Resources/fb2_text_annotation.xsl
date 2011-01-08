<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fb="http://www.gribuser.ru/xml/fictionbook/2.0" xmlns:xlink="http://www.w3.org/1999/xlink" exclude-result-prefixes="fb xlink">
  <xsl:import href="fb2_txt.xsl" />
  <xsl:param name="nodeType" />
  <xsl:output method="text" encoding="UTF-8" />

  <xsl:template name="annotation">
    <xsl:apply-templates />
  </xsl:template>

  <xsl:template match="fb:p">
    <xsl:apply-templates />
  </xsl:template>

  <xsl:template match="/*">
    <xsl:choose>
      <xsl:when test="$nodeType = 'annotation'">
        <xsl:for-each select="fb:description/fb:title-info/fb:annotation">
          <xsl:call-template name="annotation" />
        </xsl:for-each>
      </xsl:when>
      <xsl:when test="$nodeType = 'history'">
        <xsl:for-each select="fb:description/fb:document-info/fb:history">
          <xsl:call-template name="annotation" />
        </xsl:for-each>
      </xsl:when>
      <xsl:when test="$nodeType = 'custom-info'">
        <xsl:for-each select="fb:description/fb:custom-info">
          <xsl:value-of select="." />
          <xsl:text></xsl:text>
        </xsl:for-each>
      </xsl:when>
    </xsl:choose>
  </xsl:template>
</xsl:stylesheet>