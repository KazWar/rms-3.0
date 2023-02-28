import { QInputProps, QOptionGroup, QOptionGroupProps, ValidationRule } from "quasar"

export type Form = {
    /**
     * Unique id of the form
     */
    formId: number

    /**
     * Unique name of the form
     */
    name: string

    /**
     * Short description for the form
     */
    description?: string | undefined

    /**
     * The locale tied to this form
     */
    locale: string

    /**
     * The sections contained within a form.
     * Determine the rendering of steps, contains at least one section
     */
    sections: Section[]
}

export type Section = {
    /**
     * Unique id for the section within a form
     */
    id: number

    /**
     * Unique name for the section within a form
     */
    name: string

    /**
     * Short description for the section
     */
    description?: string | undefined

    /**
     * The bundles contained within a section. Contains at least one bundle
     */
    bundles: Bundle[]
}

export type Bundle = {
    /**
     * Unique id for the field within a section
     */
    id: number

    /**
     * Unique name for the bundle within a section
     */
    name: string

    /**
     * Short description for the bundle
     */
    description?: string | undefined

    /**
     * Indicates whether the bundle can repeat X times, minimum of 1
     */
    multiples: number

    /**
     * The fields contained within a bundle. Contains at least one field
     */
    fields: Field[]
}

export class Field {
    /**
     * Unique id for the field within a bundle
     */
    id: number

    /**
     * Unique name for the field within a bundle
     */
    name: string

    /**
     * Field type to determine which input component needs to be rendered
     */
    type: fieldType

    /**
     * Short description for the field
     */
    description?: string | undefined

    /**
     * The default shown field name. Has a prefix for translations of 'lbl_'
     */
    label: string

     /**
     * The default shown field value.
     */
    value?: string | undefined

    /**
     * The default tooltip for the input field. Has a prefix for translations of 'tip_'
     */
    tooltip?: string | undefined

    /**
     * Determines which table this field's data belongs to
     */
    destination: destinationType

    /**
     * Self-referencing foreign key. Links to another field for double validation,
     * E.G confirm your mail, IBAN, etc.
     */
    linkId?: number | undefined

    /**
     * Rules which apply to the field. Given as valid Javascript code strings,
     * which must be used in eval()
     */
    rules?:ValidationRule<any>[]  | undefined

    /**
     * Input styling options for Quasar inputs in JSON format
     */
    design?: JSONValue

    /**
     * Input feature options for Quasar inputs in JSON format
     */
    features?: JSONValue

    /**
     * Input mask options for Quasar inputs in JSON format
     */
    mask?: JSONValue

    /**
         * Input mask options for Quasar inputs in JSON format
         */
    custom?: JSONValue

    /**
     * Options for a dropdown field, don't work for any other field type
     */
    options?: Option[] | undefined

    constructor(field:Field){
        this.id = field.id
        this.name = field.name
        this.type = field.type
        this.description = field.description  
        this.destination = field.destination
        this.linkId = field.linkId
        this.design = field.design
        this.features = field.features
        this.mask = field.mask
        this.options = field.options
        this.custom = field.custom
        this.value = field.value

        /**
         * Remove the string prefixes
         */
        this.label = field.label?.slice(4)
        this.tooltip = field.label?.slice(4)

        /**
         * Transform the JavaScript string into runnable code
         * be extremely careful to only run retrieved data from the server
         * due to the unsafeness of using eval on user supplied input.
         * https://stackoverflow.com/questions/197769/when-is-javascripts-eval-not-evil 
         */
        this.rules = field.rules?.map((rule:ValidationRule<string>) => { return window.eval(String(rule)) })
    }
}

export type fieldType = {
    /**
     * Field name, must correspond to Quasar field names
     */
    name: string

    /**
     * Short description of the type
     */
    description?: string | undefined

    /**
     * Field sub type, must correspond to Quasar input types
     */
    subType: QInputProps["type"] | QOptionGroup["type"]
}

/**
 * Which table the data belongs to
 */
export enum destinationType {
    registration = "registration",
    purchase = "purchase"
}

/**
 * The value wrapper for form data, requested by the back-end
 */
export class FieldDTO {
     /**
     * Field name of the input
     */
    name: string

    /**
     * Determines which table this field's data belongs to
     */
    destination: destinationType

    /**
     * Field value
     */
    value: string | number

    constructor(data:FieldDTO) {
        Object.assign(this, data)
    }
}

export class Option {

    /**
     *  field value inside option
     */

    value: string

    /**
     *  field name inside the option
     */

    label: string
}