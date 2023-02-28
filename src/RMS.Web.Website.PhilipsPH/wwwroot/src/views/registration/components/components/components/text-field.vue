<script setup lang=ts>
import { Field, FieldDTO } from '@/common'
import { FormKitFrameworkContext } from '@formkit/core'
// eslint-disable-next-line @typescript-eslint/no-unused-vars
import Tooltip from '@/common/components/tooltip.vue'

const { context } = defineProps<{
    context: FormKitFrameworkContext
}>()

const { 
    name, type, tooltip,
    design, linkId, features,
    label, rules, mask, destination
 } = context.field as Field

let value:any = $ref(context.node._value)

function validate(value:any){
    const field:FieldDTO = {
        name: name,
        destination: destination,
        value: value
    }
    
    /**
     * Wrap the value in a Field DTO for the back-end to process
     */
    context.node.input(new FieldDTO(field))
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
                    class="input"
                    :ref="name"
                    :type="type.subType"
                    :label="label"
                    v-model="value"
                    :rules="rules"
                    :debounce="100"
                    @update:model-value="(value) => { validate(value) }"
                >
                    <template #append >
                        <tooltip icon="" :text="tooltip!"/>
                    </template>
                </q-input>
            </div>
        </div>
    </div>
</template>

<style lang="scss" scoped>

</style>