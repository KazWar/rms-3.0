namespace RMS.Web.Api.V2.Models
{
    public class Field
    {
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Unique name for the field within a bundle
        /// </summary>
        [Required]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Field type to determine which input component needs to be rendered
        /// </summary>
        public Type Type { get; set; } = default!;

        /// <summary>
        /// Short description for the field
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The default shown field name. Has a prefix for translations of 'lbl_'
        /// </summary>
        public string Label { get; set; } = default!;

        /// <summary>
        /// The default tooltip for the input field. Has a prefix for translations of 'tip_'
        /// </summary>
        public string? Tooltip { get; set; }

        /// <summary>
        /// Determines which table this field's data belongs to.
        /// </summary
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public DestinationTypes Destination { get; set; }

        /// <summary>
        /// Self-referencing foreign key. Links to another field for double validation,
        /// E.G confirm your mail, IBAN, etc.
        /// </summary>
        [ForeignKey("LinkId")]
        public int? LinkId { get; set; }

        /// <summary>
        /// Rules which apply to the field
        /// </summary>
        public string[]? Rules { get; set; }

        /// <summary>
        /// Input styling options for Quasar inputs in JSON format
        /// </summary>
        public Option[]? Options { get; set; }

        /// <summary>
        /// Input styling options for Quasar inputs in JSON format
        /// </summary>
        public Design? Design { get; set; }

        /// <summary>
        /// Input feature options for Quasar inputs in JSON format
        /// </summary>
        public Features? Features { get; set; }

        /// <summary>
        /// Input mask options for Quasar inputs in JSON format
        /// </summary>
        public Mask? Mask { get; set; }

        /// <summary>
        /// Input custom field options
        /// </summary>
        public Dictionary<string, string>? Custom { get; set; }

        
        public string? Value { get; set; }
    }

    public class Type
    {
        /// <summary>
        /// Type name, must correspond to one of the enum options as they're defined quasar
        /// field types.
        /// </summary>
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public FieldTypes Name { get; set; } = default!;

        /// <summary>
        /// Short description for the field
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Optional subtype
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SubTypes? SubType { get; set; }
    }

    public class Design
    {
        /// <summary>
        /// Color name for component from the Quasar Color Palette
        /// </summary>
        public string? Color { get; set; }

        /// <summary>
        /// Color name for the component label from the Quasar Color Palette
        /// </summary>
        [JsonProperty("label-color")]
        public string? LabelColor { get; set; }

        /// <summary>
        /// Color name for the background of the component from the Quasar Color Palette
        /// </summary>
        [JsonProperty("bg-color")]
        public string? BackgroundColor { get; set; }

        /// <summary>
        /// Dense mode; Makes the field more compact
        /// </summary>
        public bool? Dense { get; set; }

        /// <summary>
        /// Removes border-radius so borders are squared; Overrides rounded if both are enabled
        /// </summary>
        public bool? Square { get; set; }

        /// <summary>
        /// Applies a rounded style for the component. Is overridden by Square if both are enabled
        /// </summary>
        public bool? Rounded { get; set; }

        /// <summary>
        /// Label will be always shown above the field regardless of field content (if any)
        /// </summary>
        public bool? StackLabel { get; set; }

        /// <summary>
        /// Use 'filled' design for the field
        /// Mutally exclusive with Filled, Outlined, Standout, Borderless
        /// </summary>
        public bool? Filled { get; set; }

        /// <summary>
        /// Use 'outlined' design for the field
        /// Mutally exclusive with Filled, Outlined, Standout, Borderless
        /// </summary>
        public bool? Outlined { get; set; }

        /// <summary>
        /// Use 'standout' design for the field
        /// Mutally exclusive with Filled, Outlined, Standout, Borderless
        /// Must contain a boolean or string
        /// </summary>
        public string? Standout { get; set; }

        /// <summary>
        /// Use 'borderless' design for the field
        /// Mutally exclusive with Filled, Outlined, Standout, Borderless
        /// </summary>
        public bool? Borderless { get; set; }

        /// <summary>
        /// Do not reserve space for hint/error/counter anymore when these are not used.
        /// As a result, it also disables the animation for those. It also allows the hint/error area 
        /// to stretch vertically based on its content
        /// </summary>
        [JsonProperty("hide-bottom-space")]
        public bool? HideBottomSpace { get; set; }

        /// <summary>
        /// Style definitions to be attributed to the underlying input tag.
        /// </summary>
        [JsonProperty("input-style")]
        public string? InputStyle { get; set; }
    }

    public class Features
    {
        /// <summary>
        /// Adds a button which instantly clears the box value and sets it to null
        /// </summary>
        public bool? Clearable { get; set; }

        /// <summary>
        /// Custom icon to use for the clear button, work
        /// only when Clearable has been enabled.
        /// </summary>
        [JsonProperty("clear-icon")]
        public string? ClearIcon { get; set; }

        /// <summary>
        /// Makes the field read only
        /// </summary>
        public bool? ReadOnly { get; set; }

        /// <summary>
        /// Disables the field
        /// </summary>
        public bool? Disable { get; set; }

        /// <summary>
        /// Make field autogrow along with its content
        /// </summary>
        public bool? Autogrow { get; set; }

        /// <summary>
        /// Adds something before the input value
        /// This cannot be removed from the box
        /// </summary>
        public string? Prefix { get; set; }

        /// <summary>
        /// Adds something after the input value
        /// This cannot be removed from the box
        /// </summary>
        public string? Suffix { get; set; }

        /// <summary>
        /// Text to be displayed in the field if there is
        /// no focus on the field or there is no input value
        /// </summary>
        [JsonProperty("shadow-text")]
        public string? ShadowText { get; set; }
        
        /// <summary>
        /// Helper (hint) text which gets placed below the input
        /// </summary>
        public string? Hint { get; set; }

        /// <summary>
        /// Hide the helper (hint) text when field doesn't have focus
        /// </summary>
        [JsonProperty("hide-hint")]
        public bool? HideHint { get; set; }

        /// <summary>
        /// Focuses the field when the page is loaded.
        /// </summary>
        public bool? Autofocus { get; set; }
    }

    public class Mask
    {
        [JsonProperty("mask")]
        [MaskValidation]
        public string? Expression { get; set; }

        /// <summary>
        /// Model will be unmasked (won't contain tokens/separation characters)
        /// </summary>
        [JsonProperty("unmasked-value")]
        public bool? UnmaskedValue { get; set; }

        /// <summary>
        /// Fills string with specified characters or defaults
        /// to an underscore if given value is true to fill mask's length
        /// </summary>
        [JsonProperty("fill-mask")]
        public dynamic? FillMask { get; set; }

        /// <summary>
        /// Fills string from the right side of the mask
        /// </summary>
        [JsonProperty("reverse-fill-mask")]
        public bool? ReverseFillMask { get; set; }
    }

    /// <summary>
    /// Field types determine the basic component type which needs to be generated
    /// </summary>
    public enum FieldTypes
    {
        input,
        dropdown,
        datepicker,
        fileuploader,
        groupoption,
        slider,
        paragraphfield,
        textfieldconfirm
    }

    /// <summary>
    /// Type to determine to which database table the field data is going towards.
    /// </summary>
    public enum DestinationTypes
    {
        registration,
        purchase
    }

    /// <summary>
    /// Subtypes correspond to the quasar field options + custom options defined at the end
    /// </summary>
    public enum SubTypes
    {
        // Quasar type options for a regular input
        text,
        password,
        textarea,
        email,
        search,
        tel,
        file,
        number,
        url,
        time,
        date,
        radio,
        checkbox,
        toggle
        // Custom non-quasar implemented options below
    }

    public class Option
    {
        public string Value { get; set; } = default!;
        public string Label { get; set; } = default!;
    }
}


