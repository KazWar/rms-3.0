<script setup lang=ts>
        import { Ref } from 'vue'
    import { FormKitFrameworkContext, FormKitNode } from '@formkit/core'
    import { Field, FieldDTO } from '@/common'
    
    const { context } = defineProps<{
        context: FormKitFrameworkContext
    }>()
    
    const { 
        name,design, id, 
        features, label, mask
    } = context.field as Field
    
    const value:any = $ref()
    const disabled = $ref((context.node?.context?.disabled) as boolean)
    
    function crossValidate(value:any){
        console.log(context)
        if (!value) return false 
        const formChilds:FormKitNode[] | undefined = context.node.parent?.children
    
    
        const parentNode:FormKitNode | undefined = formChilds?.find((node:FormKitNode) => {
            if (node.context) {
                return ((node.context.field as Field).id === id) ? node : undefined
            }
        })
    
        const parentValue:FieldDTO["value"] | undefined =  (parentNode?.context?._value as FieldDTO)?.value
        
        return (value !== parentValue) ? false : true 
    }
    </script>
    
    <template>
        <div class="q-pa-xs">
            <div class="row">
                <div class="col">
                    <q-input
                        v-bind="{
                            ...(features as object),
                            ...(mask as object),
                            ...(design as object)
                        }"
                        ref=""
                        v-model="value"
                        :label="label"
                        :debounce="100"
                        :rules="[crossValidate]"
                    />
                </div>
            </div>
        </div>
    </template>
    
    <style lang="scss" scoped>
    
    </style>