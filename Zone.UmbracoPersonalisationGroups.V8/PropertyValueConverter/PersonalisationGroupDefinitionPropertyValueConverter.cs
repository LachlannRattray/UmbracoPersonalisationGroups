﻿namespace Zone.UmbracoPersonalisationGroups.V8.PropertyValueConverter
{
    using Newtonsoft.Json;
    using Umbraco.Core.Models.PublishedContent;
    using Umbraco.Core.PropertyEditors;
    using Umbraco.Web;
    using Umbraco.Web.Composing;
    using Zone.UmbracoPersonalisationGroups.Common;
    using Zone.UmbracoPersonalisationGroups.Common.GroupDefinition;

    /// <summary>
    /// Property converter to convert the saved JSON representation of a personalisation group definition to the
    /// strongly typed model
    /// </summary>
    [PropertyValueType(typeof(PersonalisationGroupDefinition))]
    [PropertyValueCache(PropertyCacheValue.All, PropertyCacheLevel.ContentCache)]
    public class PersonalisationGroupDefinitionPropertyValueConverter : PropertyValueConverterBase
    {
        public override bool IsConverter(PublishedPropertyType propertyType)
        {
            return propertyType.EditorAlias.Equals(AppConstants.PersonalisationGroupDefinitionPropertyEditorAlias);
        }

        public override object ConvertSourceToObject(PublishedPropertyType propertyType, object source, bool preview)
        {
            if (source == null || Current.UmbracoContext == null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<PersonalisationGroupDefinition>(source.ToString());
        }
    }
}