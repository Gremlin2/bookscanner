<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fb="http://www.gribuser.ru/xml/fictionbook/2.0" xmlns:xlink="http://www.w3.org/1999/xlink" exclude-result-prefixes="fb xlink">
  <xsl:import href="fb2_html.xsl" />
  <xsl:output method="xml" encoding="UTF-8" omit-xml-declaration="yes" />

  <xsl:param name="book_id" />
  <xsl:param name="images_url" />

  <xsl:template name="annotation">
    <xsl:if test="@id">
      <xsl:element name="a">
        <xsl:attribute name="name">
          <xsl:value-of select="@id" />
        </xsl:attribute>
      </xsl:element>
    </xsl:if>
    <xsl:apply-templates />
  </xsl:template>

  <xsl:template match="fb:p">
    <p>
      <xsl:if test="@id">
        <xsl:element name="a">
          <xsl:attribute name="name">
            <xsl:value-of select="@id" />
          </xsl:attribute>
        </xsl:element>
      </xsl:if>
      <xsl:apply-templates />
    </p>
  </xsl:template>

  <xsl:template match="/*">
    <xsl:for-each select="fb:description/fb:title-info/fb:annotation">
      <xsl:call-template name="annotation" />
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>