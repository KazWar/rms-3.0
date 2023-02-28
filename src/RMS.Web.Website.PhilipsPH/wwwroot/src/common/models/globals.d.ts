type Locale = {
    id:number
    code:string
    languageCode:string
    countryCode:string
    name:string
    description:string
}

type Category = {
    id:number
    name:string
    description:string
}

type JSONValue =
    | string
    | number
    | boolean
    | undefined
    | object
    | { [x: string] : JSONValue } 
    | Array<JSONValue>;