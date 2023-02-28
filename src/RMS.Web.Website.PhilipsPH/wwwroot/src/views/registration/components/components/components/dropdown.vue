<script setup lang=ts>
import { Field } from '@/common/models'
import { FormKitFrameworkContext } from '@formkit/core'
import { ref } from 'vue'

let { context } = defineProps<{
    context: FormKitFrameworkContext
}>()

const { 
    name, type, tooltip,
    design, linkId, features,
    label, rules, mask, options,
    custom
 } = context.field as Field

/**
 * Create a default value ref
 */
const value = $ref(null)
const validate = (value:any) => {
    console.log(value)
    context.node.input(value)
}
</script>

<template>
    <div class="q-px-xs">
        <div class="row">
            <div class="col">
                <q-select
                    v-bind="{
                        ...(features as object),
                        ...(mask as object),
                        ...(design as object),
                        ...(custom as object)
                    }"
                    class="dropdown"
                    v-model="value"
                    :label="label"
                    :options="options"
                    :rules="rules"
                    @update:model-value="(value) => { validate(value) }"
                >
                </q-select>
            </div>
        </div>
    </div>
</template>

<style lang="scss" scoped>
.dropdown {
    // Apparantly the size for dropdown components isn't the same as for inputs 60 for input and 40 for dropdowns
    height: 76px;
}
</style>