<script setup lang=ts>
import { Field } from '@/common/models'
import { FormKitFrameworkContext } from '@formkit/core'
import { QOptionGroup, QOptionGroupProps } from 'quasar';
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
const value = $ref([''])

/**
 * Define an emit for updating the v-model in the parent
 */
const emit = defineEmits(['update:modelValue'])

/**
 * Create a function to take in the new value and emit it
 * 
 * @param value new model value
 */
function emitInput(value: boolean): void {
    emit('update:modelValue', String(value))
}

function required (value: any) {
    return (value === null || value === '') ? false : true
}

</script>

<template>
  <div class="q-pa-lg">
    <q-option-group
        v-model="value"
        :options="options"
        :type="(type.subType as QOptionGroup['type']) "
        :rules="rules"
        :mask="mask"
        inline
        @update:model-value="(value:any) => { emitInput(value) }"
      />
  </div>
</template>
              
<style lang="scss" scoped>

</style>